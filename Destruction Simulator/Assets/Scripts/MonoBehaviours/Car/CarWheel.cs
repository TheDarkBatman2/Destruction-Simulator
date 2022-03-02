using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{   
    //private float yRotation = 0;
    public int direction;
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
         //transform.localEulerAngles = new Vector3(0 ,transform.localEulerAngles.y ,transform.localEulerAngles.z); // because of spring joint in x axis its buggy
        rb.AddRelativeTorque(direction * Vector3.forward * 1000f * Time.deltaTime); // adds torque force
        // yRotation = Input.GetAxis("Vertical")*100;
        // transform.Rotate(new Vector3(0 ,yRotation ,0));
        // rb.rotation = Quaternion.Euler(new Vector3(0 , yRotation, 0)) * rb.rotation;
        // transform.rotation
        // transform.rotation *= Quaternion.Euler(0, 1, 0);
        // rb.angularVelocity = new;
    }
}
