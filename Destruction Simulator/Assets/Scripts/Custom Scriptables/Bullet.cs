using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Bullet", menuName ="Bullets/BaseBullet")]
public class Bullet : ScriptableObject
{
    public float damage;
    public float lifeTime;
}
