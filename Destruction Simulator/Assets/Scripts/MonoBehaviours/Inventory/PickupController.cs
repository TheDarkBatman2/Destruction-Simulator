using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Item item; // just stores it
    
    private void Awake() {
        if (gameObject.GetComponent<Rigidbody>() == null){ // just to make sure
            gameObject.AddComponent<Rigidbody>();
        }
        DisableAllComponents();
    }

    private void DisableAllComponents(){
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour comp in comps)
        {
            comp.enabled = false;
        }
    }
    private void EnableAllComponents(){
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour comp in comps)
        {
            comp.enabled = true;
        }
    }

    public void OnPickup(){
        Destroy(gameObject.GetComponent<Rigidbody>());
        EnableAllComponents();

        Destroy(this);// to make sure you cant pick it up again xD
    }

    public void OnDrop(){
        DisableAllComponents();
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * 10, ForceMode.Impulse);
        rb.AddForce(this.transform.up * 10, ForceMode.Impulse);
        rb.velocity += References.Instance.playerVelocity;

        //Add random rotation
        float random = Random.Range(-2f, 2f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }

}
