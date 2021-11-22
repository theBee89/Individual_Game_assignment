using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_control : MonoBehaviour
{

    public Rigidbody2D heart;

    private float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        heart = this.GetComponent<Rigidbody2D>();
        heart.velocity = new Vector2(0, speed);
    }

    
}
