using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFroce : MonoBehaviour
{
    public float colVelocityLimit =5f;
    public float explodeRange = 2f;
    public float explodeForce = 250f;
    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.relativeVelocity;

        if (velocity.magnitude > colVelocityLimit)
        {
            this.GetComponent<DestroyedPieceController>().cause_damage(explodeForce, explodeRange);

            Destroy(this.gameObject,5);
        }
    }
}
