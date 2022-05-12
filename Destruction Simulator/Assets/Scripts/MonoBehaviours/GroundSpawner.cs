using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GroundSpawner : MonoBehaviour
{
    public List<GameObject> tilesList;
      
    public GameObject[] tilesListArray;
    GameObject groundTile;
    private Transform NextSpawnerPoint;
    public void SpawnTile(){
        groundTile = tilesList [Random.Range (0, tilesList.Count)];
        GameObject tmp = Instantiate(groundTile, NextSpawnerPoint);
        NextSpawnerPoint = tmp.transform.GetChild(1);  

        // Update navmesh
        References.Instance.navMesh.BuildNavMesh();
 }
    void Start()
    {
        tilesListArray = Resources.LoadAll<GameObject>("Valleys");
        tilesList = tilesListArray.ToList();
        NextSpawnerPoint = this.transform;

        for(int i=0; i < 5; i++){
            SpawnTile();
        }
    }


}
