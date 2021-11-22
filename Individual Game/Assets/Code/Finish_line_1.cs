using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Finish_line_1 : MonoBehaviour
{

    public Rigidbody2D finish;

    public float speed = 2f;
    public float timer;

    

    // Update is called once per frame
    void Update()
    {
        timer += 1.0f * Time.deltaTime;
        if (timer >= 120) // Once 2 minutes pass the finish line moves down the road towards the player
        {
            finish = this.GetComponent<Rigidbody2D>();
            finish.velocity = new Vector2(0, -speed);
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireTruck") // Plays sound once colliding with player
        {
            GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
