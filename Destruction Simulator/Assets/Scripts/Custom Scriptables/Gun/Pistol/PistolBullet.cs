using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PistolBullet", menuName ="Bullets/Pistol")]
public class PistolBullet : Bullet
{
    // Mechanics here
    public override void OnImpact(RaycastHit hit)
    {
        base.OnImpact(hit);

        // Destroy crystals and apply forces
        if (hit.transform){
            if (hit.transform.tag == "Crystal_Shard"){
                DestroyedPieceController _dpc = hit.transform.GetComponent<DestroyedPieceController>();
                if (_dpc){
                    Collider[] collidersInSphere = Physics.OverlapSphere(_dpc.gameObject.transform.position, bulletForceDistance);
                    foreach (var colliderInSphere in collidersInSphere)
                    {
                        DestroyedPieceController dpcInSphere = colliderInSphere.GetComponent<DestroyedPieceController>();
                        if (dpcInSphere){
                            dpcInSphere.cause_damage(5, 100);
                        }
                    }
                }
            }
            if (hit.transform.tag == "Enemy"){
                CrystofEnemyBehaviour _ceb = hit.transform.GetComponent<CrystofEnemyBehaviour>();
                if (_ceb){
                    _ceb.Damage(bulletDamage);
                }
            }

            if (hit.transform.tag == "ExplosivePlant"){
                ExplosivePlant _ep = hit.transform.GetComponent<ExplosivePlant>();
                if (_ep){
                    _ep.Explode();
                }
            }

            if (hit.rigidbody != null){
                hit.rigidbody.AddForce (-hit.normal * bulletForce, ForceMode.Impulse);
            }
        }
        
    }

    public override IEnumerator SpawnTrail(TrailRenderer trail, Vector3 endPos, RaycastHit hit)
    {
        // We dont want the base
        float time = 0;
        Vector3 startPos = trail.transform.position;
        
        while (time < 1){
            trail.transform.position = Vector3.Lerp(startPos, endPos, time);
            time += (float) ( Time.deltaTime / 0.1 );

            yield return null;
        }
        
        // Set shooting animation false
        trail.transform.position = endPos;
        // instantiate impact effect here
        // Instantiate(bulletImpactParticleSystem, endPos, Quaternion.LookRotation(hit.normal));

        Destroy(trail.gameObject);
    }
}
