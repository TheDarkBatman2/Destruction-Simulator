using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Bullet", menuName ="Bullets/BaseBullet")]
public class Bullet : ScriptableObject
{
    public float bulletDamage;
    public float bulletForce;
    public GameObject shotLine;
    public ParticleSystem bulletImpact;
    public TrailRenderer bulletTrail;

    public virtual void OnImpact(){
        // put stuff here for crystal and stuff
    }

}
