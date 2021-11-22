using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance_control : MonoBehaviour
{

    public GameObject explosion;
    

    Player_control player_Control;
    

    public GameObject fireTest;
 
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

    void Update()
    {
        if(currentHealth <= 0)
        {
            player_Control.lives -= 1;
            Player_control.score -= 400;
            GameObject e = Instantiate(explosion);
            e.transform.position = transform.position;
            Destroy(gameObject);
            
            
        }

        if (this.currentHealth <= 50 && this.currentHealth >0) // Sets ambulance "on fire" once its health is below 50
        {
            this.fireTest.SetActive(true);

        }
        else
        {
            this.fireTest.SetActive(false);
        }


    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(20);

           
        }
    }



}
