using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystofEnemyBehaviour : EnemyBehaviour
{
    public Transform tailTransform;
    private CrystofEnemy crystofStats;
    public override void Awake()
    {
        base.Awake();
        crystofStats = (CrystofEnemy) enemyStats;
        InvokeRepeating("Shoot", crystofStats.startShootDelay, crystofStats.repeatShootDelay);
    }
    public override void Damage(float amount)
    {
        base.Damage(amount);
    }
    
    public override void Death()
    {
        base.Death();

    }
    
    public override void UpdateHpBar(){
        base.UpdateHpBar();
    }

    public void Shoot(){
        GameObject _projectile = Instantiate(crystofStats.projectilePrefab, tailTransform.position, Quaternion.identity);
        Rigidbody _rb = _projectile.GetComponent<Rigidbody>();
        Vector3 force = References.Instance.truckTransform.position-tailTransform.position;
        _rb.AddForce(force.normalized * Mathf.Pow(force.magnitude, 0.5f) * crystofStats.projectileForwardSpeed, ForceMode.Impulse);
        _rb.AddForce(-Vector3.down * Mathf.Pow(force.magnitude, 0.5f) * crystofStats.projectileTopSpeed, ForceMode.Impulse);
        _projectile.GetComponent<CrystofProjectile>().damage = crystofStats.projectileDamage;
    }
}
