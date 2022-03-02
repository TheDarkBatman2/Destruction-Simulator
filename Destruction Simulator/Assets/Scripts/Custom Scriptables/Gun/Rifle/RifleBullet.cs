using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RifleBullet", menuName ="Bullets/Rifle")]
public class RifleBullet : Bullet
{
    // Mechanics here
    public override void OnImpact()
    {
        base.OnImpact();
        
    }
}
