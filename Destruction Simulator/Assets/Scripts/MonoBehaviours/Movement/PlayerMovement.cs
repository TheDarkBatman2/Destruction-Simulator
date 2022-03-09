
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravityScale;
    public float movementSpeed = 0.5f;
    private Rigidbody rb;
    // Start is called before the first frame update

    public Transform groundCheck;
    public float groundDistance = 0.4f; // max distance from ground after that it will say you are grounded
    public LayerMask groundMask; // layers it can have collision with it
    public float jumpHeight = 3.0f;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // jump system
        isGrounded = Physics.Raycast(groundCheck.position ,Vector3.down ,groundDistance ,groundMask);
        

        if (Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
        }

        // movement system
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * movementSpeed * Time.deltaTime ;
        
        rb.MovePosition(transform.position + move);
    }
}