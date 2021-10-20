using UnityEngine;

public class BombPlanting : MonoBehaviour
{
    public GameObject bombPrefab;
    public LayerMask plantSpots;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Fire();
        }        
    }

    private void Fire(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray , out hitInfo , 100f , plantSpots)){
            Instantiate(bombPrefab , hitInfo.point , Quaternion.LookRotation(hitInfo.normal));
        }

    }
}
