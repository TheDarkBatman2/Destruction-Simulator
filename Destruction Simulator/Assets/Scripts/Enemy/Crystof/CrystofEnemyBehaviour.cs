using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystofEnemyBehaviour : EnemyBehaviour
{
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
}
