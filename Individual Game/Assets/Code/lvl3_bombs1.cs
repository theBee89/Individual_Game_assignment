using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_bombs1 : MonoBehaviour
{
    private float bombSpeed = 3f;
    public Rigidbody2D bomb;
    public GameObject explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        bomb.velocity = new Vector2(0, bombSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -11 || transform.position.y > 20)
        {
            Destroy(gameObject);
        }
        bomb.velocity = new Vector2(0, bombSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lvl_3")
        {
            Instantiate(explosion, bomb.transform.position, bomb.transform.rotation);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "lvl3_car")
        {
            Instantiate(explosion, bomb.transform.position, bomb.transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            GameObject e = Instantiate(explosion);
            e.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
