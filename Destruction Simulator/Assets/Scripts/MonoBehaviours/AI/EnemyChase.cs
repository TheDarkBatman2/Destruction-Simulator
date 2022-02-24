using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public float HP = 100;
    public GameObject player;

    void Update()
    {
       this.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
    void OnCollisionEnter(Collision col)
    {
        Vector3 velocity = col.relativeVelocity;
        if(col.gameObject.tag=="Crystal")
        {
            Destroy(col.gameObject);//
            HP-=velocity.magnitude;
        }
        if(HP<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
