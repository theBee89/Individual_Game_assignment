using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance_control : MonoBehaviour
{

    public GameObject explosion;

    private int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            GameObject e = Instantiate(explosion);
            e.transform.position = transform.position;
            Destroy(gameObject);
        }
    }


    private void TakeDamage(int damage)
    {
        currentHealth -= 20;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(20);
        }
        Destroy(collision.gameObject);
    }
}
