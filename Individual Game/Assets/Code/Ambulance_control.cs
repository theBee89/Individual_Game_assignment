using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance_control : MonoBehaviour
{

    public GameObject explosion;

    public GameObject explosion2;

    private int maxHealth = 100;
    public int currentHealth;

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


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Bomb")
        {
            TakeDamage(20);
            Instantiate(explosion2);
            explosion2.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
        }
    }
}
