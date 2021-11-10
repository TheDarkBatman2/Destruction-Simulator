using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshFilter meshFilter;
    private Mesh originalMesh, clonedMesh;

    private Vector3[] vertices;
    private int[] triangles;
    private bool isCloned;
    public MeshCollider meshCollider;

    public GameObject vertexWeight;
    void Awake()
    {
        
        meshCollider = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.sharedMesh;
        clonedMesh = new Mesh(); //2

        clonedMesh.name = "clone";
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;
        meshFilter.mesh = clonedMesh; 

        vertices = clonedMesh.vertices;
        triangles = clonedMesh.triangles;
        isCloned = true;

        for (int i = 0; i < vertices.Length; i++){
            GameObject tempObject = Instantiate(vertexWeight,transform.position + Vector3.Scale(vertices[i] , transform.lossyScale), Quaternion.Euler(0, 0, 0));
            // tempObject.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            // tempObject.GetComponent<FixedJoint>().autoConfigureConnectedAnchor = true;
        }
        // vertices[0] = new Vector3(0, 0, 0);
        clonedMesh.vertices = vertices;
        clonedMesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
