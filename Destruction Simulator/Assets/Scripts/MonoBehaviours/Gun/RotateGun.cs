using UnityEngine;
public class RotateGun : MonoBehaviour {

    public float rotationSpeed = 5f;
    public float xOffset = 1f;
    public float zOffset = 1f;
    public float yOffset = 1f;

    void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, References.Instance.playerHeadTransform.rotation, Time.deltaTime * rotationSpeed);
        transform.position = References.Instance.playerHeadTransform.position + xOffset * References.Instance.playerHeadTransform.right + zOffset * References.Instance.playerHeadTransform.forward + yOffset * References.Instance.playerHeadTransform.up;
    }

}