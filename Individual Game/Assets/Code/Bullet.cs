using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

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
        
    }
}
