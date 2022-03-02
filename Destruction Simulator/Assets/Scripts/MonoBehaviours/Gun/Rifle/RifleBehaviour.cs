using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RifleBehaviour : MonoBehaviour
{
    public RifleItem rifleItem;
    public VisualEffect muzzleFlash;
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
                // muzzleFlash.Play(); 
                
                // Start shooting animation 

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
        RaycastHit hit;
        Vector3 targetPoint = ray.GetPoint(100);

        // Shoots raycast
        if (Physics.Raycast(ray, out hit, References.Instance.shootableLayers)){
            targetPoint = hit.point;
        }

        // Trail effect
        TrailRenderer bulletTrail = Instantiate(rifleItem.rifleBullet.bulletTrail, GunTip.position, Quaternion.identity);
        StartCoroutine(SpawnTrail(bulletTrail, targetPoint, hit));

        // Apply forces and stuff
        if (hit.transform){
            if (hit.transform.tag == "Crystal_Shard"){
                DestroyedPieceController _dpc = hit.transform.GetComponent<DestroyedPieceController>();
                if (_dpc){
                    _dpc.cause_damage(rifleItem.rifleBullet.bulletForce, 10);
                }
            }
            if (hit.rigidbody != null){
                hit.rigidbody.AddForce (-hit.normal * rifleItem.rifleBullet.bulletForce, ForceMode.Impulse);
            }
        }


        // calculate direction
        Vector3 directionWithoutSpread = targetPoint - GunTip.position;
        
        // spread
        float x = Random.Range(-rifleItem.bulletSpread ,rifleItem.bulletSpread);
        float y = Random.Range(-rifleItem.bulletSpread ,rifleItem.bulletSpread);

        // direction + spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x ,y ,0); // + player velocity to carry that

        
        // create bullet
        //  //GameObject currentBullet = Instantiate(rifleItem.bulletPrefab ,GunTip.position ,rifleItem.bulletPrefab.transform.rotation);
        // rotate bullet towards direction
        // //currentBullet.transform.up = directionWithSpread.normalized;

        // add force
        // //currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.up * rifleItem.rifleItem.rifleBullet.bulletForce, ForceMode.Impulse);
        // //currentBullet.GetComponent<Rigidbody>().velocity += References.Instance.playerVelocity;
        // Destroy(currentBullet ,currentBullet.GetComponent<RifleBulletBehaviour>().rifleBullet.lifeTime); // you can also add this in RifleItem object but its better to be there
        
        // recoil ? check for shotgun
        References.Instance.playerRb.AddForce(-directionWithSpread.normalized * rifleItem.recoilForce ,ForceMode.Impulse);
    }

    IEnumerator SpawnTrail(TrailRenderer trail, Vector3 endPos, RaycastHit hit){
        float time = 0;
        Vector3 startPos = trail.transform.position;
        
        while (time < 1){
            trail.transform.position = Vector3.Lerp(startPos, endPos, time);
            time += (float) ( Time.deltaTime / 0.1 );

            yield return null;
        }
        
        // Set shooting animation false
        trail.transform.position = endPos;
        // instantiate impact effect here
        // Instantiate(bulletImpactParticleSystem, endPos, Quaternion.LookRotation(hit.normal));

        Destroy(trail.gameObject);

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
