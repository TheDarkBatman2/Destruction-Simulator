using UnityEngine;
public class RotateGun : MonoBehaviour {

    public Item test;
    public float rotationSpeed = 5f;
    public Vector3 positionOffset = new Vector3(0 , 0.63f ,0);

    void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, References.Instance.playerHeadTransform.rotation, Time.deltaTime * rotationSpeed);
        transform.position = References.Instance.playerTransform.position + positionOffset;
    }

}