using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RifleBullet", menuName ="Bullets/Rifle")]
public class RifleBullet : Bullet
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
                    _dpc.cause_damage(bulletForce, 10);
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
            Debug.Log(time);
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
