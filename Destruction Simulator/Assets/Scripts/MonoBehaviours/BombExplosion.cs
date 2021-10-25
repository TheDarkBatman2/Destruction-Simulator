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
        Destroy(gameObject);
    }

    private void OnDestroy() {
        soundManager.PlaySound3D(SoundLibrary.sfxLibrary3D["bomb_explosion"] , transform.position);
    }
}
