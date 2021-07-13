using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Capsule : ColidableEnemy
{


    void Start()
    {
        health = 50;
        speed = 10;
        damage = 40;
        agent.speed = speed;
        attackCooldown = 5;
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        layerMask = LayerMask.GetMask("Enemy");

    }


 






}
