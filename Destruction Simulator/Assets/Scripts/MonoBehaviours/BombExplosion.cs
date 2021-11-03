using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public SoundManager soundManager;
    public float explosionDelay = 2f;
    void Start()
    {
        Invoke("Explode" , explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider nearby in colliders){
            MeshDestroy md = nearby.gameObject.GetComponent<MeshDestroy>();
            if (md != null){
                md.DestroyMesh();
            }
            Rigidbody rg = nearby.GetComponent<Rigidbody>();

            if(rg != null){
                rg.AddExplosionForce(2000f , transform.position, 10f);
            }
        }
        Destroy(this.gameObject);

    }

    private void OnDestroy() {
        SoundManager.PlaySound3D(SoundLibrary.sfxLibrary3D["bomb_explosion"] , transform.position);
    }
}