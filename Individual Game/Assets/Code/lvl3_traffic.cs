using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_traffic : MonoBehaviour
{

    public Rigidbody2D traffic;
    public GameObject explosion;
    public Transform car;

    private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        traffic = this.GetComponent<Rigidbody2D>();
        traffic.velocity = new Vector2(0, -speed); // Sets the speed and direction the vehicles travel 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -12) // Destroys the cars once they are out of the screen view 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fire")
        {
            Instantiate(explosion, car.position, car.rotation);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "lvl_3" || collision.gameObject.tag == "lvl3_car") // Keeps the trffic from spawning on top of eachother
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            Instantiate(explosion, car.position, car.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
