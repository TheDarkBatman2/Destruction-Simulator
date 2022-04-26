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
    private NavMeshAgent thisAgent;
    public Transform targetTransform;
    
    // Initilize

    private void Awake() {
        hpBar=  gameObject.GetComponentInChildren<TMP_Text>();
        hp = enemyStats.enemyHp;
        damage = enemyStats.enemyDamage;
        thisAgent = gameObject.GetComponent<NavMeshAgent>();
        UpdateHpBar();
    }
    private void Start(){
        if (targetTransform == null){
            targetTransform = References.Instance.playerTransform;
    }
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
        if (Vector3.Distance(transform.position, References.Instance.playerTransform.position) <= References.Instance.criticalDistance){ // it will go out of the formation if its close enough to player
            thisAgent.SetDestination(References.Instance.playerTransform.position);
        }
        else {
            thisAgent.SetDestination(targetTransform.position);
        }
    }

    private void Update() {
        Move();
    }

    void OnCollisionEnter(Collision col)
    {
        float force = col.impulse.magnitude;
        if(col.gameObject.tag=="Crystal_Shard"){
            // if (velocity.magnitude > 0.1){
            Damage(Mathf.Round(force * 100f) / 100f); // * crystal type damage
            // }
        }
    }
    
}
