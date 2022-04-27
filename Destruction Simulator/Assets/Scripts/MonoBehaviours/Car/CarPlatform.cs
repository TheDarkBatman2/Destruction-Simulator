using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            Rigidbody rb = this.GetComponent<Rigidbody>();
            other.transform.position += rb.velocity * Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "Player"){
            Rigidbody rb = this.GetComponent<Rigidbody>();
            other.transform.position += rb.velocity * Time.deltaTime;
        }
    }
}
