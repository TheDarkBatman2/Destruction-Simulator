using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class References : MonoBehaviour
{
    public static References Instance { get; private set; }
    // Player
    private Vector3 playerPrevPos;
    private Vector3 playerCurrPos;
    public Rigidbody playerRb;
    public Transform playerTransform;
    public Transform playerHeadTransform;
    public Vector3 playerVelocity;
    public Transform truckTransform;
    private Vector3 prevTruckPos;
    private Vector3 curTruckPos;
    public Vector3 truckVelocity;
    // public LayerMask wallsLayer;
    // Gun
    public Transform gunContainer;
    public Transform gunHolder;
    public Transform gunCursor;
    public LayerMask shootableLayers;
    public TMP_Text itemPanelCounts;
    public Image itemPanelTexture;
    // Camera
    public Camera fpsCam;
    // Item
    public Item blankItem;
    // Objects
    public GameObject sphere;
    // Navmesh
    public NavMeshSurface navMesh;
    public float criticalDistance; // means if enemy is closer than this distance it will go out of formation
    // Game Stats
    public int curStage = 1;
    private void Awake() 
    {
        playerPrevPos = playerTransform.position;
        playerCurrPos = playerTransform.position;
        prevTruckPos = truckTransform.position;
        curTruckPos = truckTransform.position;
        Instance = this;
    }

    private void Update() {
        playerVelocity = (playerCurrPos - playerPrevPos) / Time.deltaTime;
        playerPrevPos = playerCurrPos;
        playerCurrPos = playerTransform.position;

        truckVelocity = (curTruckPos - prevTruckPos) / Time.deltaTime;
        prevTruckPos = curTruckPos;
        curTruckPos = truckTransform.position;
    }

    public void StartSpawningGunTrail(Bullet bulletScript, TrailRenderer trail, Vector3 endPos, RaycastHit hit){
        StartCoroutine(bulletScript.SpawnTrail(trail, endPos, hit));
    }

}
