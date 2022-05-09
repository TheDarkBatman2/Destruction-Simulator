using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "BaseEnemy", menuName ="Enemy/BaseEnemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Stats")]
    public string enemyName = "Default Enemy";
    public float enemyHp = 20f;
    public float enemyDamage = 2f;
    public float enemySpeed = 2f;
    public float score = 200f;

}
