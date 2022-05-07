using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealthSystem : MonoBehaviour
{
    public float hp = 20f;

    public float Damage(float hitPoint){
        if (hp - hitPoint < 0){
            hp = 0;
            // death scene here
        }
        else{
            hp -= hitPoint;
        }
        return hp;
    }
}
