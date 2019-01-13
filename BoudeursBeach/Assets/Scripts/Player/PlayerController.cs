using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float health =10f;
    public float speed =5f;

    Animator anim;

    // Start is called before the first frame update
    void Start(){
        anim =GetComponent<Animator>();
        //anim.speed=2f;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            this.Attack();
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            this.Attack2();
        }
    }

    void FixedUpdate(){
        this.Move();
        this.Turn();
    }

    void Move(){
        float moveVertical   =Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveHorizontal =Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float currVelocity =Mathf.Max(Mathf.Abs(Input.GetAxis("Vertical")), Mathf.Abs(Input.GetAxis("Horizontal")));
        this.anim.SetFloat("Velocity",currVelocity);
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
        this.anim.SetTrigger("isAttacking");
    }

    void Attack2(){
        this.anim.SetTrigger("isAttacking2");
    }



}
