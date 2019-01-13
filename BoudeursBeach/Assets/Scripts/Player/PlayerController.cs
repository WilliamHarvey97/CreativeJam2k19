using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour{
    public float health =10f;
    public float damage =4f;
    public float speed =5f;

    Animator anim;
    string  currentAnimName ="";

    GameObject sword;

    void Start(){
        anim =GetComponent<Animator>();

        sword =this.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 L Clavicle/Bip01 L UpperArm/Bip01 L Forearm/Bip01 L Hand/Sword").gameObject;
    }


    void Update(){
      
        Debug.Log("VIE:"+this.health);
        if(Input.GetKeyDown(KeyCode.Space)){
            
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            this.AttackAnim1();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            this.AttackAnim2();
        }
    }

    void FixedUpdate(){
        this.Move();
        this.Turn();
    }

    void Move(){
        float moveVertical =0;
        moveVertical   =Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveHorizontal =Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float currAnimVelocity =Mathf.Max(Mathf.Abs(Input.GetAxis("Vertical")), Mathf.Abs(Input.GetAxis("Horizontal")));
        this.anim.SetFloat("Velocity",currAnimVelocity);

        
        // if(Input.GetAxis("Vertical") !=0 || Input.GetAxis("Horizontal") !=0){
        //     this.anim.SetBool("isWalking",true);
        // }
        // if(Input.GetAxis("Vertical") ==0 && Input.GetAxis("Horizontal") ==0){
        //     this.anim.SetBool("isWalking", false);
        // }
        
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
        sword.GetComponent<SwordCollision>().isAttacking =true;
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
        Debug.Log(rand);
        if(!(this.anim.GetCurrentAnimatorStateInfo(0).IsName(currentAnimName))){
        sword.GetComponent<SwordCollision>().swordHasHitEnemy =false;
        sword.GetComponent<SwordCollision>().isAttacking =false;
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
        Attack(damage);
        
    }
    void AttackAnim2(){
        this.anim.Play("long_attack_melee");
        this.currentAnimName="long_attack_melee";
        Attack(damage*2);
    }

}
