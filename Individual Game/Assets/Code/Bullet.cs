using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosion2;
    public float bulletSpeed = 10f;
    public Rigidbody2D bullet;

    // Start is called before the first frame update
    void Start()
    {
       bullet.velocity = transform.right* bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10.5f)
        {
            Destroy(this.gameObject);
        }
        bullet.velocity = transform.right * bulletSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyCar_1")
        {
            Debug.Log("Collision Detected");
            GameObject e = Instantiate(explosion);
            e.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        

        
        
    }

}
