using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner ground_spanwer;
    public GameObject CrystalObj;
    void Awake()
    {
        ground_spanwer = GameObject.FindObjectOfType<GroundSpawner>();
    }
    void OnTriggerExit(Collider other){
        if(other.name=="Player"){
            ground_spanwer.SpawnTile();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }


}
