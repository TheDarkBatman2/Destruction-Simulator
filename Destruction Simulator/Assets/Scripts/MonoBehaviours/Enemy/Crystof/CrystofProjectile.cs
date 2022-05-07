using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystofProjectile : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Truck"){
            References.Instance.truckHpScript.Damage(damage);
            Destroy(this.gameObject);
        }
        if (References.Instance.projectileDestructionLayer == (References.Instance.projectileDestructionLayer | (1 << other.gameObject.layer))) {
            Destroy(this.gameObject);
        }
    }
}
