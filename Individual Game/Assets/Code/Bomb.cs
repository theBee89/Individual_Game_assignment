using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombSpeed = 4f;
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
    
    }
    


}
