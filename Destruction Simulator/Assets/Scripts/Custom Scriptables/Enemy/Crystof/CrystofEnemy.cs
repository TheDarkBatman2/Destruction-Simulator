using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Crystof", menuName ="Enemy/Crystof")]
public class CrystofEnemy : Enemy
{
    public float startShootDelay = 2.0f;
    public float repeatShootDelay = 6.0f;
    public float projectileForwardSpeed = 10f;
    public float projectileTopSpeed = 2f;
    public float projectileDamage = 2f;
    public GameObject projectilePrefab;
}
