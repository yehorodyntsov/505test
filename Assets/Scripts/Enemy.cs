using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    public float attackCooldown;
    public GameObject target;
    public LayerMask layerMask;
    public NavMeshAgent agent;


    public abstract void Attack();
    private void Update()
    {
        SetDestination();
        if (health <= 0)
        {
            Die();
        }
    }
   
    public virtual void Die()
    {

        Destroy(gameObject);
        SpawnManager sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        Player player = target.gameObject.GetComponent<Player>();
        player.kills++;
        player.UpdatePlayerText();
        if (sm != null)
        {
            sm.createRandomEnemy();
        }

    }
    
    public virtual void SetDestination()
    {
        agent.SetDestination(target.transform.position);
    }

    public virtual IEnumerator LowerHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackCooldown);           
            Attack();
        }
    }




}
