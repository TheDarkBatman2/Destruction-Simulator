using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GroundSpawner : MonoBehaviour
{
    public List<GameObject> tilesList;
      
    public GameObject[] tilesListArray;
    GameObject groundTile;
    Vector3 NextSpawnerPoint;
    public void SpawnTile(){
        groundTile = tilesList [Random.Range (0, tilesList.Count)];
        print(tilesList.Count);
        GameObject temp = Instantiate(groundTile, NextSpawnerPoint, Quaternion.identity);
        NextSpawnerPoint=temp.transform.GetChild(1).transform.position;

        // Update navmesh
        References.Instance.navMesh.BuildNavMesh();
 }
    void Start()
    {
        tilesListArray = Resources.LoadAll<GameObject>("Valleys");
        tilesList = tilesListArray.ToList();

        for(int i=0; i <2; i++){
            SpawnTile();
        }

    }

}
