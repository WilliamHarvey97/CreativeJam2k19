using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour{
    public float health =10f;
    public float speed =5f;

    Animator anim;
    string  currentAnimName ="";

    void Start(){
        anim =GetComponent<Animator>();
        //anim.speed=2f;
    }


    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            this.Attack();
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            this.Attack2();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            this.Attack3();
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


    void Attack(){
        //this.anim.SetTrigger("isAttacking");
        
    }

    void Attack2(){
        this.anim.SetTrigger("isAttacking2");
        Random.seed = System.DateTime.Now.Millisecond;
        float rand=Random.Range(0,3);
        Debug.Log(rand);
        if(!(this.anim.GetCurrentAnimatorStateInfo(0).IsName(currentAnimName))){
        switch(rand){
            case 0:
                this.anim.Play("attack_melee_01");
                this.currentAnimName="attack_melee_01";
            break;

            case 1:
                this.anim.Play("attack_melee_11");
                this.currentAnimName="attack_melee_11";
            break;

            case 2:
                this.anim.Play("attack_melee_13");
                this.currentAnimName="attack_melee_13";
            break;
        }
        }
        
    }
    void Attack3(){
        this.anim.Play("long_attack_melee");
    }

}
