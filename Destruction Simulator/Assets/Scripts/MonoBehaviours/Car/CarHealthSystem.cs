using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealthSystem : MonoBehaviour
{
    public float hp = 20f;

    private void Awake() {
        References.Instance.truckSlider.maxValue = hp;
        References.Instance.truckSlider.value = hp;
    }

    public float Damage(float hitPoint){
        if (hp - hitPoint < 0){
            hp = 0;
            References.Instance.truckSlider.value = hp;
            Destroy(this.transform);
        }
        else{
            hp -= hitPoint;
            References.Instance.truckSlider.value = hp;
        }
        return hp;
    }
}
