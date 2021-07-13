using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : Enemy
{
    //public int health;
    //public int damage;
    //public float speed;
    //float attackCooldown;
    
    //Coroutine coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        speed = 5;
        damage = 70;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        target = GameObject.Find("Player");      
        attackCooldown = 7;
        layerMask = LayerMask.GetMask("Enemy");

        StartCoroutine("LowerHealth");
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
        if (health < 1)
        {
            Die();
        }

    }

    

    public override void Attack()
    {
        if (Physics.Linecast(this.transform.position, target.transform.position, layerMask))
        {
            Debug.Log("!blocked");
        }
        else
        {
            Player player = target.gameObject.GetComponent<Player>();
            player.health -= damage;
            Debug.Log("Player Health = " + player.health.ToString());
            Debug.Log("asdf");
        }



    }

    public override IEnumerator LowerHealth()
    {
        while (true) 
        {
            yield return new WaitForSeconds(attackCooldown); 
            Attack(); 
        }
    }

    public override void SetDestination()
    {
        agent.SetDestination(target.transform.position);
    }
}
