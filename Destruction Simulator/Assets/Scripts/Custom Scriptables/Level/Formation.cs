using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [System.Serializable]
// [CreateAssetMenu(fileName = "BaseFormation", menuName ="Enemy/Formation")]
public class Formation : MonoBehaviour
{   
    // Monobehaviour that acts like scriptable object
    // [Header("Info")]
    public string formationName = "Basic Formation";
    public float xfollowOffset;
    public Transform[] formationTransforms;

    private void Update() {
        transform.position = new Vector3(References.Instance.truckTransform.position.x + xfollowOffset, transform.position.y, transform.position.z);
    }
}
