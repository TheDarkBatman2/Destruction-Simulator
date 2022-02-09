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
    private float nextTimeToFire = 0f;

    void Awake(){
        reloaded = true;
        clipAmmo = Mathf.Min(rifleItem.clipSize ,totalAmmo);
        totalAmmo -= clipAmmo;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            if (clipAmmo > 0 && reloaded) // idk if reloaded is necesary
            {
                nextTimeToFire = Time.time + 1f/rifleItem.fireRate;
                Shoot();
                clipAmmo--;
                if (clipAmmo == 0){
                    reloaded = false;
                    StartCoroutine(Reload());
                }
            }
            else if (totalAmmo > 0 && reloaded == false){
                // warn here
            }
            else if (totalAmmo == 0){
                // warn here
            }
            
        }
    }

    IEnumerator Reload(){

        yield return new WaitForSeconds(rifleItem.reloadTime);
        clipAmmo = Mathf.Min(rifleItem.clipSize ,totalAmmo);
        totalAmmo -= clipAmmo;
        reloaded = true;
    }

    public void Shoot()
    {  
        // Find target location
        Ray ray = References.Instance.fpsCam.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0));
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit))
        //     Instantiate(References.Instance.sphere, hit.point, Quaternion.Euler(Vector3.zero));
                    

        // We just get static point on ray to make our spread global and not changable
        Vector3 targetPoint = ray.GetPoint(100);

        // calculate direction
        Vector3 directionWithoutSpread = targetPoint - GunTip.position;
        print(GunTip.position);
        
        // spread
        float x = Random.Range(-rifleItem.bulletSpread ,rifleItem.bulletSpread);
        float y = Random.Range(-rifleItem.bulletSpread ,rifleItem.bulletSpread);

        // direction + spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x ,y ,0); // + player velocity to carry that

        // create bullet
        GameObject currentBullet = Instantiate(rifleItem.bulletPrefab ,GunTip.position ,Quaternion.identity);
        // rotate bullet towards direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        // add force
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * rifleItem.bulletSpeed);
        currentBullet.GetComponent<Rigidbody>().velocity += References.Instance.playerVelocity;
        Destroy(currentBullet ,currentBullet.GetComponent<RifleBulletBehaviour>().rifleBullet.lifeTime); // you can also add this in RifleItem object but its better to be there
        
        // recoil ? check for shotgun
        References.Instance.playerRb.AddForce(-directionWithSpread.normalized * rifleItem.recoilForce ,ForceMode.Impulse);
    }

    private void OnDisable() {
        // disable ammo counter
    }

    private void OnEnable() {
        // it will disable realoading to avoid bugs
        if (clipAmmo < rifleItem.clipSize && reloaded == false){
            StartCoroutine(Reload());
        }
        // activate ammo counter
        
    }
}
