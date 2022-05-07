using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Crystof", menuName ="Enemy/Crystof")]
public class CrystofEnemy : Enemy
{
    public float startShootDelay = 2.0f;
    public float repeatShootDelay = 6.0f;
    public float projectileSpeed = 10f;
    public float projectileDamage = 2f;
    public GameObject projectilePrefab;
}
