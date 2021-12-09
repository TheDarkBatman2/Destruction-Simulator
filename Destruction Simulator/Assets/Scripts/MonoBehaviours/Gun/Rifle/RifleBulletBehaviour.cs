using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBulletBehaviour : MonoBehaviour
{
    public RifleBullet rifleBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
