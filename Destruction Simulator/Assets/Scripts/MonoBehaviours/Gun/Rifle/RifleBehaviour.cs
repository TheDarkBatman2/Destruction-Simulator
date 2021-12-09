using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBehaviour : MonoBehaviour
{
    public RifleItem rifleItem;
    public Transform GunTip;
    public int totalAmmo = 500;
    public int clipAmmo = 0;
    public bool reloaded;
    public Camera fpsCam;

    void Awake(){
        reloaded = true;
        clipAmmo = Mathf.Min(rifleItem.clipSize ,totalAmmo);
        totalAmmo -= clipAmmo;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (totalAmmo > 0 && reloaded)
            {
                Shoot();
            }
            
        }
    }

    public void Shoot()
    {  
        // Find target location
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0));
        RaycastHit hit;

        // If it hit something or not
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit)){
            targetPoint = hit.point;
        }
        else{
            targetPoint = ray.GetPoint(1000); // just away from player to make it destroy later
        }

        // calculate direction
        Vector3 directionWithoutSpread = targetPoint - GunTip.position;
        
        // spread
        float x = Random.Range(-rifleItem.bulletSpread ,rifleItem.bulletSpread);
        float y = Random.Range(-rifleItem.bulletSpread ,rifleItem.bulletSpread);

        // direction + spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x ,y ,0);

        // create bullet
        GameObject currentBullet = Instantiate(rifleItem.bulletPrefab ,GunTip.position ,Quaternion.identity);
        // rotate bullet towards direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        // add force
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * rifleItem.bulletSpeed ,ForceMode.Impulse);
        Destroy(currentBullet ,currentBullet.GetComponent<RifleBulletBehaviour>().rifleBullet.lifeTime); // you can also add this in RifleItem object but its better to be there
    }
}
