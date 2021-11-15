using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float bombSpeed = 3f;
    public Rigidbody2D bomb;
    private float moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        bomb.velocity = new Vector2(0, -bombSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -11)
        {
            Destroy(gameObject);
        }
        bomb.velocity = new Vector2(0, -bombSpeed);

    }
    


}
