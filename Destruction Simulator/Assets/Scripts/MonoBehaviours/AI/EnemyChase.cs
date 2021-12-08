using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject player;

    void Update()
    {
       enemy.SetDestination(player.transform.position);
    }
}
