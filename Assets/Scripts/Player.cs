using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public int health = 10;
    public int damage;
    public float speed = 20;
    public Camera fpsCam;
    public int kills;
    public int damageSum;
    public TMP_Text killsText;
    public TMP_Text damageText;
    public TMP_Text healthText;

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
            
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            Debug.Log(hit.transform.gameObject.name);
            if (enemy != null)
            {
                
                damageSum += damage;
                UpdatePlayerText();
                enemy.health -= damage;                
                
            }

        }

    }

    public void UpdatePlayerText()
    {
        killsText.text = "Kills: " + kills.ToString();
        damageText.text = "Damage: " + damageSum.ToString();
        healthText.text = "Health: " + health.ToString();
    }
}
