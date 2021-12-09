using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Rifle", menuName ="Item/Guns/Rifle")]
public class RifleItem : Item
{
    public float reloadTime;
    public float fireRate;
    public int clipSize;
    public float bulletSpeed;
    public float bulletSpread;
    public GameObject bulletPrefab;
    public float recoilForce;
   

}
