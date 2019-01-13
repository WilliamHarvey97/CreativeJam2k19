using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour{
    // Start is called before the first frame update
    public bool swordHasHitEnemy;
    public GameObject enemyHitBySword;
    void Start(){
        swordHasHitEnemy =false;
    }

    // Update is called once per frame
    void Update(){
    }

    void OnTriggerEnter(Collider other){
        enemyHitBySword =other.gameObject;
        if(enemyHitBySword.CompareTag("Enemy")){
            swordHasHitEnemy =true;
        }
    }
}
