using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarHealthSystem : MonoBehaviour
{
    public float hp = 20f;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI HighScoreTxt ;
    public GameObject DeathUI;


    private void Awake() {
        References.Instance.truckSlider.maxValue = hp;
        References.Instance.truckSlider.value = hp;
    }

    public float Damage(float hitPoint){
        if (hp - hitPoint < 0){
            hp = 0;
            References.Instance.truckSlider.value = hp;
            Death();
            //Destroy(this.gameObject);

        }
        else{
            hp -= hitPoint;
            References.Instance.truckSlider.value = hp;
        }
        return hp;
    }

    private void Death(){
        Cursor.lockState = CursorLockMode.None;
        DeathUI.SetActive(true);
        Time.timeScale = 0;
        
        ScoreTxt.text="SCORE : " + References.Instance.GetScore().ToString();
        //add highscore
        if(References.Instance.GetScore() > PlayerPrefs.GetInt("HIGHSCORE",0))
        {
            PlayerPrefs.SetInt("HIGHSCORE",(int) References.Instance.GetScore());
        }
        HighScoreTxt.text = "HIGHSCORE : "+PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();

    }
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
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
