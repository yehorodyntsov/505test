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
        target.gameObject.GetComponent<Player>().health-=damage;
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
                player.health-=damage;
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
            // Debug.Log("Stop");
        }
    }

    public override void SetDestination()
    {
        agent.SetDestination(target.transform.position);
    }
}
