using UnityEngine;

public class BombPlanting : MonoBehaviour
{
    public SoundManager soundManager;
    public GameObject bombPrefab;
    public LayerMask plantSpots;
    public LayerMask explodableObjects;
    public GameObject throwableObj; 
    public GameObject CRS;

    int x =0;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            //throwBall();
        }  
        if (Input.GetButtonDown("Fire2")){
            //BombPlant();
            //Instantiate(CRS,new Vector3(x,5,0), Quaternion.identity );
            x+=10;
        }      
    }

    private void throwBall()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
           
      Vector3 dir = r.GetPoint(1) - r.GetPoint(0);
 
      GameObject bullet = Instantiate(throwableObj, r.GetPoint(2), Quaternion.LookRotation(dir));
 
      bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;
      Destroy(bullet, 3);
      
    }
    private void BombPlant()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray , out hitInfo , 100f)){
            if (plantSpots == (plantSpots | 1<<hitInfo.transform.gameObject.layer)){
                GameObject bombClone = Instantiate(bombPrefab , hitInfo.point , Quaternion.LookRotation(hitInfo.normal));
                
                BombExplosion bombExplosion = bombClone.AddComponent<BombExplosion>();
                bombExplosion.soundManager = soundManager;
                bombExplosion.explodableObjects = explodableObjects;

            }
        }

    }
}