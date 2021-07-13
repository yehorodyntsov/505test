using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 10;
    public int damage;
    public float speed = 20;
    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        damage = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Debug.Log("alsdgj");
            Shoot();
        }
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            //Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            
            //hit.transform.gameObject.
            if (enemy != null)
            {
                enemy.health -= damage;
                Debug.Log("enemy health = " + enemy.health.ToString());
            }

        }

    }
}
