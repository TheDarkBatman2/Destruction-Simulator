using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    private Vector3 playerPrevPos;
    private Vector3 playerCurrPos;
    public static References Instance { get; private set; }
    // Player
    public Rigidbody playerRb;
    public Transform playerTransform;
    public Transform playerHeadTransform;
    public Vector3 playerVelocity;
    // Gun
    public Transform gunContainer;
    public Transform gunHolder;
    // Camera
    public Camera fpsCam;
    // Item
    public Item blankItem;

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
