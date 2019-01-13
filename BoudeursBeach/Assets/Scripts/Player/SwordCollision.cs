using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour{
    public GameObject attackParticles;
    public bool isNormalAttacking;
    public bool isHardAttacking;
    public bool swordHasHitEnemy;
    public GameObject enemyHitBySword;
    void Start(){
        isNormalAttacking =false;
        isHardAttacking =false;
        swordHasHitEnemy =false;
    }

    // Update is called once per frame
    void Update(){
    }

    void OnTriggerEnter(Collider other){
        if(isNormalAttacking || isHardAttacking){
        if(!swordHasHitEnemy){
            enemyHitBySword =other.gameObject;
            if(enemyHitBySword.CompareTag("Enemy") && enemyHitBySword){  //if the enemy is still existing
                swordHasHitEnemy =true;
                
                if(isNormalAttacking){
                    enemyHitBySword.GetComponent<Enemy>().TakeDamage(4);
                    Camera.main.GetComponent<CameraShake>().shakeAmount=0.45f;
                    Camera.main.GetComponent<CameraShake>().shakeDuration=0.05f;
                    Instantiate(this.attackParticles,transform.position,Quaternion.identity);
                }
                if(isHardAttacking){
                    enemyHitBySword.GetComponent<Enemy>().TakeDamage(8);
                    Camera.main.GetComponent<CameraShake>().shakeAmount=0.6f;
                    Camera.main.GetComponent<CameraShake>().shakeDuration=0.1f;
                }
                
                enemyHitBySword =null;
                return;
            }
        }
    }
    }
}
