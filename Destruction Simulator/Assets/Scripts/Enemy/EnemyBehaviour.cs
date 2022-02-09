using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy enemyStats;
    private float hp;
    private float damage;
    private TMP_Text hpBar;
    
    // Initilize

    private void Awake() {
        hpBar=  gameObject.GetComponentInChildren<TMP_Text>();
        hp = enemyStats.enemyHp;
        damage = enemyStats.enemyDamage;
        UpdateHpBar();
    }

    public virtual void Damage(float amount){
        if (hp <= amount){
            Death();
        }
        else{
            hp -= amount;
            UpdateHpBar();
        }
    }

    // must be over
    public virtual void Death(){
        Destroy(this.gameObject);
    }

    public virtual void UpdateHpBar(){
        hpBar.text = hp.ToString();
    }

    public virtual void Move(){
        // Move here
    }
    
}
