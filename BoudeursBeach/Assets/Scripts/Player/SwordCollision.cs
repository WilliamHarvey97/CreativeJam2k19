using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour{
    // Start is called before the first frame update
    public bool isAttacking;
    public bool swordHasHitEnemy;
    public GameObject enemyHitBySword;
    void Start(){
        isAttacking =false;
        swordHasHitEnemy =false;
    }

    // Update is called once per frame
    void Update(){
    }

    void OnTriggerEnter(Collider other){
        if(isAttacking){
        if(!swordHasHitEnemy){
            enemyHitBySword =other.gameObject;
            if(enemyHitBySword.CompareTag("Enemy") && enemyHitBySword){  //Destroy other object
                swordHasHitEnemy =true;
                 enemyHitBySword.GetComponent<Enemy>().TakeDamage(4);
                Camera.main.GetComponent<CameraShake>().shakeDuration=0.05f; 
                 enemyHitBySword =null;
                 return;
            }
        }
    }
    }
}
