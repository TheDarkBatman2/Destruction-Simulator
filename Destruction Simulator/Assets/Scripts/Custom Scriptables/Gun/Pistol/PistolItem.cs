using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Pistol", menuName ="Item/Guns/Pistol")]
public class PistolItem : Item
{
    public float reloadTime;
    public float fireRate;
    public int clipSize;
    public float bulletSpread;
    public float recoilForce;
    public PistolBullet pistolBullet;

}
