using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_car : MonoBehaviour
{

    public Rigidbody2D fireCar;
    public GameObject explosion;
    public Transform car;
    public GameObject car2;

    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        fireCar = this.GetComponent<Rigidbody2D>();
        fireCar.velocity = new Vector2(0, -speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Fire-Truck")
        {
            Instantiate(explosion, car.position, car.rotation);
        }
    }

    
}
