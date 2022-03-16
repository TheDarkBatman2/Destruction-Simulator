using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner ground_spanwer;
    public GameObject CrystalObj;
    void Start()
    {
        ground_spanwer=GameObject.FindObjectOfType<GroundSpawner>();
        //spawnCrystal();
    }
    void OnTriggerExit(Collider other){
        if(other.name=="Player"){
            ground_spanwer.SpawnTile();
            Destroy(gameObject,5);//edit later
        }
    }

    void spawnCrystal()
    {
        Transform CrystalSpawnPoint = transform.GetChild(2);
        Instantiate(CrystalObj, CrystalSpawnPoint.position, CrystalSpawnPoint.rotation);
    }
}
