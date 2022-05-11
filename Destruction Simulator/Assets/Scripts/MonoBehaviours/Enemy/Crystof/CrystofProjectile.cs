using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystofProjectile : MonoBehaviour
{
    public float damage;
    private void Awake() {
        Destroy(this.gameObject, 20f);
    }
}
