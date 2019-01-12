using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public int damagePoints;
    public Collider targetEnemy;

    // Methods
    void Awake() {
        // Keep scene heirarchy clean
        transform.parent = GameObject.FindGameObjectWithTag("Projectiles").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
