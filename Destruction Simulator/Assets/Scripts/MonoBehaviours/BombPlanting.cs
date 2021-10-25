using UnityEngine;

public class BombPlanting : MonoBehaviour
{
    public SoundManager soundManager;
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
        if (Physics.Raycast(ray , out hitInfo , 100f)){
            if (plantSpots == (plantSpots | 1<<hitInfo.transform.gameObject.layer)){
                GameObject bombClone = Instantiate(bombPrefab , hitInfo.point , Quaternion.LookRotation(hitInfo.normal));
                BoxCollider bombCollider = bombClone.AddComponent<BoxCollider>(); 
                // we can add collider to prefab itself but we have more control if we add it from code
                BombExplosion bombExplosion = bombClone.AddComponent<BombExplosion>();
                bombExplosion.soundManager = soundManager;
                // you can add component itself to prefab later , search in internet ( its task )
                bombCollider.size = bombCollider.size * 2;
                
            }
        }

    }
}
