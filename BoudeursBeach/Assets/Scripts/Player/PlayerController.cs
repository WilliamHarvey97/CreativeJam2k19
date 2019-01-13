using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
    public int health;
    public float speed = 5f;
    public int score;
    public int money;

    // Start is called before the first frame update
    void Start(){
        money = 0;
        score = 0;
        health = 10; 
    }

    void FixedUpdate(){
        this.Move();
        this.Turn();
    }

    void Move(){
        float moveVertical   =Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveHorizontal =Input.GetAxis("Horizontal") * speed * Time.deltaTime; 
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
}
