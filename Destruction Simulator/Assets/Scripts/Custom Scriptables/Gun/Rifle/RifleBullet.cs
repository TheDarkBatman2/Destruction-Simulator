using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RifleBullet", menuName ="Bullets/Rifle")]
public class RifleBullet : ScriptableObject
{
    public float damage;
    public float lifeTime;
}
