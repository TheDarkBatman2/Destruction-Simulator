using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static References Instance { get; private set; }
    private Vector3 playerPrevPos;
    private Vector3 playerCurrPos;

    // Player
    public Rigidbody playerRb;
    public Transform playerTransform;
    public Transform playerHeadTransform;
    public Vector3 playerVelocity;
    // Gun
    public Transform gunContainer;
    public Transform gunHolder;
    public Transform gunCursor;
    public LayerMask shootableLayers;
    // Camera
    public Camera fpsCam;
    // Item
    public Item blankItem;
    // Objects
    public GameObject sphere;

    private void Awake() 
    {
        playerPrevPos = playerTransform.position;
        playerCurrPos = playerTransform.position;
        Instance = this;
    }

    private void Update() {
        playerVelocity = (playerCurrPos - playerPrevPos) / Time.deltaTime;
        playerPrevPos = playerCurrPos;
        playerCurrPos = playerTransform.position;
    }

}
