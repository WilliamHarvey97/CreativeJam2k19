using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour{
    public float speed =10f;
    public float aggroFactor =1.5f;
    public float aggroDistance =10f;
    Transform player;
    Transform exit;
    NavMeshAgent nav;


    void Awake (){
        player =GameObject.FindGameObjectWithTag("Player").transform;
        exit   =GameObject.FindGameObjectWithTag("Exit").transform;
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        nav.speed =speed;
    }


    void Update (){
        this.Move();
    } 

    void Move(){
        if(Vector3.Distance(this.transform.position, player.position)>aggroDistance){
            nav.SetDestination(exit.position);
            nav.speed =speed;
        }
        else{
            nav.SetDestination(player.position);
            nav.speed =speed*aggroFactor;
        }
    }

    void Attack(){

    }
    void Die(){

    }
}