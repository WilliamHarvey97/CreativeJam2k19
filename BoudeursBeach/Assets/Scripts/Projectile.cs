using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float damagePoints;
    public Enemy targetEnemy;

    public void Initialize(Enemy enemy, float damagePoints) {
        this.targetEnemy = enemy;
        this.damagePoints = damagePoints;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Ground")) {
            targetEnemy.health -= damagePoints;
            Destroy(gameObject);
        }
    }
}
