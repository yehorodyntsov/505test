using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cube : ColidableEnemy
{
    

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        speed = 20;
        damage = 100;       
        agent.speed = speed;      
        attackCooldown = 3;
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        layerMask = LayerMask.GetMask("Enemy");
    }



   
}
