using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarHealthSystem : MonoBehaviour
{
    public float hp = 20f;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI HighScoreTxt ;


    private void Awake() {
        References.Instance.truckSlider.maxValue = hp;
        References.Instance.truckSlider.value = hp;
    }

    public float Damage(float hitPoint){
        if (hp - hitPoint < 0){
            hp = 0;
            References.Instance.truckSlider.value = hp;


            //Destroy(this.gameObject);

            ScoreTxt.text="SCORE : " +References.Instance.playerScoreTextUi.text.ToString();
            //add highscore

        }
        else{
            hp -= hitPoint;
            References.Instance.truckSlider.value = hp;
        }
        return hp;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "ProjectileDamage"){
            Damage(other.gameObject.GetComponent<CrystofProjectile>().damage);
            Destroy(other.gameObject);
        }
        // if (References.Instance.projectileDestructionLayer == (References.Instance.projectileDestructionLayer | (1 << other.gameObject.layer))) {
        //     Destroy(other.gameObject);
        // }
    }
}
