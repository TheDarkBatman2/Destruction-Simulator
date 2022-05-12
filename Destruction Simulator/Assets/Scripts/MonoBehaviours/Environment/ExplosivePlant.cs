using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivePlant : MonoBehaviour
{
    public GameObject vfx;
    public float explosionRange = 5f;
    public float explodeDeadline = 2f;
    public void Explode(){
        GameObject temp = Instantiate(vfx, transform.position, Quaternion.identity);
        temp.transform.parent = null;

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (Collider nearby in colliders){
            //if nearby is structure:
            if (nearby.gameObject.tag == "Enemy"){
                EnemyBehaviour _eb = nearby.gameObject.GetComponent<EnemyBehaviour>();
                _eb.Damage(Mathf.Max(explosionRange - (nearby.transform.position-transform.position).magnitude, 0) * 10f);
            }
        }

        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        float forcePower = collision.relativeVelocity.magnitude;
        if (forcePower >= explodeDeadline){
            Explode();
        }
    }

}
