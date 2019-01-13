using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public int damagePoints;
    public Enemy targetEnemy;

    public void Initialize(Enemy enemy, int damagePoints) {
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
