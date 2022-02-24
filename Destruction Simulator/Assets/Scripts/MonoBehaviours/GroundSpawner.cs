using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 NextSpawnerPoint;
    public void SpawnTile(){
        GameObject temp = Instantiate(groundTile, NextSpawnerPoint, Quaternion.identity);
        NextSpawnerPoint=temp.transform.GetChild(1).transform.position;
 }
    void Start()
    {
        for(int i=0; i <10; i++){
            SpawnTile();
        }

    }

}
