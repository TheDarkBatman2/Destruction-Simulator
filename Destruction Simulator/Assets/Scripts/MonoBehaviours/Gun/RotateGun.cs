using UnityEngine;
public class RotateGun : MonoBehaviour {

    public Item test;
    public float rotationSpeed = 5f;
    public Transform headTransform;
    public Transform playerTransform;
    public Vector3 positionOffset = new Vector3(0 , 0.63f ,0);

    void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, headTransform.rotation, Time.deltaTime * rotationSpeed);
        transform.position = playerTransform.position + positionOffset;
    }

}