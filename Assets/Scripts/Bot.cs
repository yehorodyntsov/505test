using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public virtual void Die() {
            
            Destroy(gameObject);
     SpawnManager sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
     if (sm != null)
        {
            sm.createRandomEnemy();
        }   
        
    }
    public abstract void SetDestination(); 
    public abstract IEnumerator LowerHealth();
    



}
