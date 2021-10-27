using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public SoundManager soundManager;
    public float explosionDelay = 2f;
    public List<GameObject> explodeObjects ;
    void Start()
    {
        explodeObjects= new List<GameObject>();
        Invoke("Explode" , explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //game objects that have to be destroyed at explosion
        if(other.gameObject.layer == 9)
        {
            
            explodeObjects.Add(other.gameObject);
        }
        
    }
    public void Explode()
    {
         foreach (GameObject explodeObject in explodeObjects)
         {
             Destroy(explodeObject);   
         }
        Destroy(this.gameObject);

    }

    private void OnDestroy() {
        soundManager.PlaySound3D(SoundLibrary.sfxLibrary3D["bomb_explosion"] , transform.position);
    }
}
