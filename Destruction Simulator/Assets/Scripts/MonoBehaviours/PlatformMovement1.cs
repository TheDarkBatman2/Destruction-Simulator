using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement1 : MonoBehaviour
{   
    Rigidbody rb;
    private void Start() {
        rb = this.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other) {
        other.gameObject.GetComponent<Rigidbody>().velocity = rb.velocity;
    }
}
