using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerLauncher : MonoBehaviour
{
    public float radius;
    public float reloadTime;
    private float timeBeforeReloaded;

    public void Initialize(float radius, float reloadTime) {
        this.radius = radius;
        this.reloadTime = reloadTime;
    }

    void Start() {
        timeBeforeReloaded = 0.0f;
    }

    void Update()
    {
        if(!isReloading()) {
            Collider[] enemiesInRadius = Physics.OverlapSphere(this.transform.position, radius);
            enemiesInRadius = Array.FindAll(enemiesInRadius, enemy => enemy.CompareTag("Enemy"));
            if(enemiesInRadius.Length == 0) return;

            Collider closestEnemy = enemiesInRadius[0]; 
            for(int i = 1; i < enemiesInRadius.Length; ++i) {
                if(isCurrentEnemyCloser(enemiesInRadius[i], closestEnemy)) {
                    closestEnemy = enemiesInRadius[i];
                }
            }

            AttackEnemy(closestEnemy);
            timeBeforeReloaded = reloadTime;
        } else {
            timeBeforeReloaded -= Time.deltaTime;
        }
    }

    bool isCurrentEnemyCloser(Collider currentEnemy, Collider closestEnemy) {
        return (currentEnemy.transform.position - this.transform.position).magnitude < 
            (closestEnemy.transform.position - this.transform.position).magnitude;
    }

    virtual public void AttackEnemy(Collider enemy) {
        Debug.Log("Attack : " + enemy.name);
    }

    bool isReloading() {
        return timeBeforeReloaded > 0.0f;
    }
}
