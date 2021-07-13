using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : Enemy
{
    
    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        speed = 5;
        damage = 70;
        agent.speed = speed;         
        attackCooldown = 7;
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        layerMask = LayerMask.GetMask("Enemy");
        StartCoroutine("LowerHealth");
    }

    public override void Attack()
    {
        if (!Physics.Linecast(this.transform.position, target.transform.position, layerMask))
            
        {
            Player player = target.gameObject.GetComponent<Player>();
            player.health -= damage;
            player.UpdatePlayerText();

        }
    }
}
