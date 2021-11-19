using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance_control : MonoBehaviour
{

    public GameObject explosion;
    public GameObject e;

    Player_control player_Control;
    public GameObject explosion2;

    public GameObject fire;
    
    public Transform ambulance;

    public int lives = 3;
    public bool isFire = false;

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
            player_Control.lives -= 1;
            Player_control.score -= 400;
            GameObject e = Instantiate(explosion);
            e.transform.position = transform.position;
            Destroy(gameObject);
            
            
        }
        
        
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 50 && isFire == false)
        {
          e = Instantiate(fire, ambulance.position, ambulance.rotation);
          e.transform.position = ambulance.transform.position;
            isFire = true;
           
        }
        if (currentHealth <= 10)
        {
            Destroy(e);
        }

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
