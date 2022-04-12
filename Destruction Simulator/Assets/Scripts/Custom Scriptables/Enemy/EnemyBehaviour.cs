using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy enemyStats;
    private float hp;
    private float damage;
    private TMP_Text hpBar;
    public NavMeshAgent thisAgent;
    
    // Initilize

    private void Awake() {
        hpBar=  gameObject.GetComponentInChildren<TMP_Text>();
        hp = enemyStats.enemyHp;
        damage = enemyStats.enemyDamage;
        thisAgent = gameObject.GetComponent<NavMeshAgent>();
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
        thisAgent.SetDestination(References.Instance.playerTransform.position);
    }

    private void Update() {
        Move();
    }
    
}
