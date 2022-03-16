using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Bullet", menuName ="Bullets/BaseBullet")]
public abstract class Bullet : ScriptableObject
{
    public float bulletDamage;
    public float bulletForce;
    public float bulletForceDistance = 0.90f;
    public GameObject shotLine;
    public ParticleSystem bulletImpact;
    public TrailRenderer bulletTrail;

    public virtual void OnImpact(RaycastHit hit){
        // Put hit effects here
    }
    
    public virtual IEnumerator SpawnTrail(TrailRenderer trail, Vector3 endPos, RaycastHit hit){
        // Put trail code here
        yield return null; // Its just to make sure it returns something
    }  

}
