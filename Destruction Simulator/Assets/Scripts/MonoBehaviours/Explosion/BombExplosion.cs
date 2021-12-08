using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public SoundManager soundManager;
    public float explosionDelay = 2f;
    public LayerMask explodableObjects;
    public float explodeRange = 4f;
    public float explodeForce = 500f;
    void Start()
    {
        Invoke("Explode" , explosionDelay);
    }


    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRange);
        foreach (Collider nearby in colliders){
            //if nearby is structure:
            if(nearby.gameObject.layer==9)
            {
                nearby.GetComponent<DestroyedPieceController>().cause_damage(explodeForce, explodeRange);
                Destroy(nearby.gameObject,5);
            }
        }
        Destroy(this.gameObject);

    }

    private void OnDestroy() {
        SoundManager.PlaySound3D(SoundLibrary.sfxLibrary3D["bomb_explosion"] , transform.position);
    }
}