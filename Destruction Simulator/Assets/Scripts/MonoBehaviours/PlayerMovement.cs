using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float zoomSpeed = 200f;
    public float rotateSpeed = 100f;
    public GameObject structure;

    void Start()
    {
    }

    void Update()
    {

        // movement system
        float x = Input.GetAxis("Horizontal");
        float y =Input.GetAxis("Mouse ScrollWheel");
        float z = Input.GetAxis("Vertical");


        //move up and down
        Vector3 moveUp = (transform.up * z) * movementSpeed * Time.deltaTime ;
        transform.position+=moveUp;

        //zoom in and out
        Vector3 moveFor = (transform.forward * y) * zoomSpeed * Time.deltaTime ;
        transform.position+=moveFor;

        //rotate around the structure
        transform.RotateAround(structure.transform.position, structure.transform.up * -x, rotateSpeed*Time.deltaTime);

    
    }
}
