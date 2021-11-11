using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance_control : MonoBehaviour
{

    public GameObject explosion;

    Player_control player_Control;
    public GameObject explosion2;

    public int lives = 3;

    private int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player_Control = GameObject.Find("Player_car1").GetComponent<Player_control>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            GameObject e = Instantiate(explosion);
            e.transform.position = transform.position;
            Destroy(gameObject);
            player_Control.lives -= 1;
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
            
            GameObject e = Instantiate(explosion2);
            e.transform.position = transform.position;
            Destroy(collision.gameObject);
        }
    }
}
