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
        _projectile.GetComponent<Rigidbody>().AddForce((References.Instance.truckTransform.position-tailTransform.position).normalized * crystofStats.projectileSpeed, ForceMode.Impulse);
        _projectile.GetComponent<CrystofProjectile>().damage = crystofStats.projectileDamage;
    }
}
