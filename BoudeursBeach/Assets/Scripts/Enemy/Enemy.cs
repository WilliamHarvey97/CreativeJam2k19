using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour{

    PlayerController playerController;
    public int moneyGain = 10;
    public int scoreGain = 1;
    public int health = 10;
    public float attackSpeed =7f; /* In seconds */
    public float attackRadius =5f;
    public int damage =2;
    public float speed =10f;
    public float aggroFactor =1.5f;
    public float aggroDistance =10f;
    public Vector3 velocity = new Vector3();

    Vector3 lastFramePosition =new Vector3();
    float distanceWithPlayer;
    GameObject player;
    GameObject exit;
    NavMeshAgent nav;
    bool isAttacking = false;
    float timeLeftUntilAttack;
    Vector3 exitPosition;

    void Awake (){
        player =GameObject.FindGameObjectWithTag("Player");
        exit   =GameObject.FindGameObjectWithTag("Exit");
        this.playerController = player.GetComponent<PlayerController>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        nav.speed =speed;

        timeLeftUntilAttack =attackSpeed;
        distanceWithPlayer =0f;
        exitPosition = GameObject.FindGameObjectWithTag("Exit").transform.position;
    }

    void Update (){
        if(Vector3.Distance(exitPosition,this.transform.position) <= 5f) {
            this.Exit();
        }
       
        if(this.health <= 0) {
            this.Die();
        }

        
        if (this.isInRangeToAttack()) {
            this.Attack();
        }
        else {
            if (this.timeLeftUntilAttack < this.attackSpeed) {
                this.isAttackReady();
            }
        }
        
        
    } 

    void FixedUpdate(){
        Vector3 ownPosition     = this.transform.position;
        Vector3 playerPosition  = player.transform.position;
        Vector3 exitPosition    = exit.transform.position;
        this.distanceWithPlayer = Vector3.Distance(ownPosition, playerPosition);
        this.Move(playerPosition, exitPosition);

        Vector3 finalPosition = this.transform.position;
        this.calculateVelocity(finalPosition);
        this.DrawVelocityVector();
        this.lastFramePosition =finalPosition;
    }

    void calculateVelocity(Vector3 finalPosition) {
        this.velocity = (finalPosition - this.lastFramePosition)/Time.deltaTime;
    }

    void Move(Vector3 playerPosition, Vector3 exitPosition){
        if(!isAttacking){
            if(this.distanceWithPlayer > aggroDistance){
                nav.SetDestination(exitPosition);
                nav.speed =speed;
            }
            else{
                nav.SetDestination(playerPosition);
                nav.speed =speed*aggroFactor;
            }
        } else {
            nav.speed = 0f;
        }
    }
    
    void Attack() {
        this.isAttacking = true;
        if (this.isAttackReady() && isInRangeToAttack()) {
           this.playerController.health -= this.damage;
        }
    }

    bool isInRangeToAttack() {
        return this.distanceWithPlayer <= this.attackRadius;
    }

    bool isAttackReady() {
        timeLeftUntilAttack -= Time.deltaTime;
        if (timeLeftUntilAttack <= 0) {
            timeLeftUntilAttack = this.attackSpeed;
            this.isAttacking = false;
            return true;
        } 
        return false;
    }

    void Die() {
        Destroy(this.gameObject);
        this.playerController.score +=  scoreGain;
        this.playerController.money += moneyGain;
        
    }

    void Exit() {
        Destroy(this.gameObject);
        this.playerController.score -=  scoreGain;
        this.playerController.money -= moneyGain;
        GameObject.Find("Game").GetComponent<Game>().EnemiesGone++;
    }

    void DrawVelocityVector(){
        Debug.DrawRay(this.transform.position, this.velocity, Color.blue);
    }
}