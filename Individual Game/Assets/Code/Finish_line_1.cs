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
        if (timer >= 10)
        {
            finish = this.GetComponent<Rigidbody2D>();
            finish.velocity = new Vector2(0, -speed);
        }
    }
}
