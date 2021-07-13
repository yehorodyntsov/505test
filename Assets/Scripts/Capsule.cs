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
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        layerMask = LayerMask.GetMask("Enemy");


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
        target.gameObject.GetComponent<Player>().health -= damage;
    }

    public override IEnumerator LowerHealth()
    {
        while (true) 
        {
            yield return new WaitForSeconds(attackCooldown); 
            Attack(); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.health -= damage;
                //Debug.Log("Player health = " + player.health.ToString());
                //player.health -= damage;
                colisionCoroutine = StartCoroutine(LowerHealth());

            }


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.CompareTag("Player"))
        {
            //StopCoroutine(LowerHealthColision(player));
            StopCoroutine(colisionCoroutine);
            //Debug.Log("Stop");
        }
    }

    public override void SetDestination()
    {
        agent.SetDestination(target.transform.position);
    }






}
