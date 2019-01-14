using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    public float health =10f;
    public float damage =4f;
    public GameObject game;
    public float speed =5f;
    public int score;

    Animator anim;
    string  currentAnimName ="";

    GameObject sword;

    bool isDashing;
    public float dashSpeed;
    private Vector3 dashOrientation;

    public GameObject dashParticles;
    private float dashTime;
    public float startDashTime;
    bool canDash = true;

    bool scoreAdd =true;

    void Start(){
        score =0;
        anim =GetComponent<Animator>();
        sword =this.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 L Clavicle/Bip01 L UpperArm/Bip01 L Forearm/Bip01 L Hand/Sword").gameObject;
    }


    void Update(){
      if(sword.GetComponent<SwordCollision>().swordHasHitEnemy && scoreAdd){
        score +=5;
        game.GetComponent<Game>().addMoney(2);
        scoreAdd=false;
        StartCoroutine(this.AddScore());
        
      }
      
        if(Input.GetKeyDown(KeyCode.Space)){
            
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            this.AttackAnim1();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            this.AttackAnim2();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && this.canDash){
            this.Dash();
            StartCoroutine(this.dashCooldown());
            this.canDash=false;
        }
        if(this.health <=0) {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        
    }
    IEnumerator AddScore(){
        yield return new WaitForSeconds(1f);
        this.scoreAdd =true;
    }
    IEnumerator dashCooldown(){
        yield return new WaitForSeconds(0.5f);
        this.canDash=true;
    }

    void FixedUpdate(){
        if(isDashing){
            if(dashTime<=0){
                isDashing=false;
                dashTime =startDashTime;
                this.GetComponent<Rigidbody>().velocity =new Vector3(0f,0f,0f);
                this.GetComponent<CapsuleCollider>().isTrigger=false;
            }
            else{
                Camera.main.GetComponent<CameraShake>().shakeAmount=0.3f;
                Camera.main.GetComponent<CameraShake>().shakeDuration=0.1f;
                anim.Play("attack_melee_11");
                //this.GetComponent<CapsuleCollider>().isTrigger=true;
                dashTime -= Time.deltaTime;
                Instantiate(this.dashParticles,transform.position,Quaternion.identity);
                transform.Translate(dashOrientation*dashSpeed, Space.World);
            }
        }  


        this.Move();
        this.Turn();
    }

    void Move(){
        float moveVertical =0;
        moveVertical   =Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveHorizontal =Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float currAnimVelocity =Mathf.Max(Mathf.Abs(Input.GetAxis("Vertical")), Mathf.Abs(Input.GetAxis("Horizontal")));
        this.anim.SetFloat("Velocity",currAnimVelocity);
        
       transform.Translate(moveHorizontal, 0f, moveVertical, Space.World);
    }

    void Turn(){
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundRayHit;

        if(Physics.Raycast(rayOrigin, out groundRayHit, LayerMask.GetMask("Ground"))) {
            Vector3 mousePosition =groundRayHit.point;
            mousePosition.y =this.transform.position.y;
            transform.LookAt(mousePosition);
        }
    }


    void Attack(float attackDamage){
        //sword.GetComponent<SwordCollision>().isNormalAttacking =true;
        // if(sword.GetComponent<SwordCollision>().swordHasHitEnemy){
        //     GameObject enemy = sword.GetComponent<SwordCollision>().enemyHitBySword;
        //     if(enemy.CompareTag("Enemy") && enemy){  //Destroy other object
        //         enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        //     }
        // }
        
    }

    void AttackAnim1(){
        this.anim.SetTrigger("isAttacking2");
        Random.seed = System.DateTime.Now.Millisecond;
        float rand=Random.Range(0,2);
        if(!(this.anim.GetCurrentAnimatorStateInfo(0).IsName(currentAnimName))){
        sword.GetComponent<SwordCollision>().swordHasHitEnemy =false;
        sword.GetComponent<SwordCollision>().isNormalAttacking =false;
        sword.GetComponent<SwordCollision>().isHardAttacking =false;
        switch(rand){
            case 0:
                this.anim.Play("attack_melee_01");
                this.currentAnimName="attack_melee_01";
            break;

            case 1:
                this.anim.Play("attack_melee_13");
                this.currentAnimName="attack_melee_13";
            break;

            // case 2:
            //     this.anim.Play("attack_melee_13");
            //     this.currentAnimName="attack_melee_13";
            // break;
        }
        }
        //sword.GetComponent<SwordCollision>().isHardAttacking =false;
        sword.GetComponent<SwordCollision>().isNormalAttacking =true;
        Attack(damage);
        
    }
    void AttackAnim2(){

        this.anim.Play("long_attack_melee");
        this.currentAnimName="long_attack_melee";
        
        //sword.GetComponent<SwordCollision>().isNormalAttacking =false;
        sword.GetComponent<SwordCollision>().isHardAttacking =true;
        Attack(damage*2);
    }

    void Dash(){
        this.dashTime =this.startDashTime;
        this.dashOrientation=this.transform.forward;
        isDashing=true;
    }



     void OnTriggerEnter(Collider other){
         if(isDashing){
             if(other.CompareTag("Enemy")){
                  
             }
         }
     }


    void OnParticleCollision(GameObject other){
       
        List<ParticleCollisionEvent> collisionEvents =new List<ParticleCollisionEvent>();
        int numCollisions =this.dashParticles.GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);
        
        Rigidbody rb =other.GetComponent<Rigidbody>();
        if(rb){
            Debug.Log("ASDAFS");
        }

        for(int i=0; i<numCollisions; i++){
            
        }
        if(other.CompareTag("Enemy")){
            
            other.GetComponent<Enemy>().TakeDamage(100);
        }
    }

}
