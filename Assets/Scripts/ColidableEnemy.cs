using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColidableEnemy : Enemy
{
    public Coroutine colisionCoroutine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {                           
                player.health -= damage;
                player.UpdatePlayerText();
                colisionCoroutine = StartCoroutine(LowerHealth());

            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.CompareTag("Player"))
        {           
            StopCoroutine(colisionCoroutine);           
        }
    }

    public override void Attack()
    {       
        target.gameObject.GetComponent<Player>().health -= damage;
    }
}
