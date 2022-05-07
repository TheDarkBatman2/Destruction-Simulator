using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupController : MonoBehaviour
{
    public Item item; // just stores it
    
    private void Awake() {
        if (gameObject.GetComponent<Rigidbody>() == null){ // just to make sure all items have rigid body
            gameObject.AddComponent<Rigidbody>();
        }
        if (gameObject.GetComponent<NavMeshObstacle>() == null){
            gameObject.AddComponent<NavMeshObstacle>();
        }
        DisableAllComponents();
        this.gameObject.layer = 18; // Fps layer
        
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

    public void OnPickup(){ // some functionalities are already in EnableItemInSlot so we dont need to put that here 
        Destroy(gameObject.GetComponent<Rigidbody>());
        GetComponent<Collider>().enabled = false; // so it doesnt push other objects 
        EnableAllComponents();

        Destroy(this);// to make sure you cant pick it up again xD
    }

    public void OnDrop(){
        DisableAllComponents(); // We cant have DisableItemInSlot when dropping an item so we must put it here aswell
        
        References.Instance.itemPanelTexture.sprite = null; // Sets the texture of item panel
        References.Instance.itemPanelCounts.text = "---"; // Sets the panel counts to ---
        GetComponent<Collider>().enabled = true; // so it doesnt push other objects 
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(References.Instance.playerHeadTransform.forward * 20, ForceMode.Impulse);
        // Adjust item position
        References.Instance.rotateGunScript.xOffset -= item.inHandOffset.x;
        References.Instance.rotateGunScript.yOffset -= item.inHandOffset.y;
        References.Instance.rotateGunScript.zOffset -= item.inHandOffset.z;
        // rb.velocity += References.Instance.playerVelocity;

        //Add random rotation
        float random = Random.Range(-2f, 2f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }

}
