using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerLauncherBallistic : TowerLauncher
{

    /* HAS TO BE AN OBJECT IMPLEMENTING projectile.cs AND BallisticMotion.cs!! */
    public GameObject projectile;
    public float arcPeak;
    public float projectileInitialVelocity;
    public int damagePoints;

    private float gravity = 9.81f;
    
    public override void AttackEnemy(Collider enemy) {
        //Debug.Log("Attack : " + enemy.name);
        gravity = 9.81f;
        Vector3 fireVel, impactPos;
        Vector3 diff = enemy.transform.position - this.transform.position;
        Vector3 diffGround = new Vector3(diff.x, 0f, diff.z);
        Enemy enemyComponent = enemy.gameObject.GetComponent<Enemy>();

        if (fts.solve_ballistic_arc_lateral(this.transform.position, projectileInitialVelocity, enemy.transform.position, enemyComponent.velocity, arcPeak, out fireVel, out gravity, out impactPos)) {
            transform.forward = diffGround;

            GameObject projObject = GameObject.Instantiate<GameObject>(projectile);
            Projectile proj = projObject.GetComponent<Projectile>();
            proj.Initialize(enemyComponent, damagePoints);

            BallisticMotion motion = projObject.GetComponent<BallisticMotion>();
            motion.Initialize(this.transform.position, gravity);
            motion.AddImpulse(fireVel);
        }
    }
}
