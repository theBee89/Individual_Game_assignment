using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar_1 : MonoBehaviour
{

    public Rigidbody2D enemyCar;
    private float speed = 2f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        enemyCar = this.GetComponent<Rigidbody2D>();
        enemyCar.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1.0f * Time.deltaTime;
        if(timer >= 3f)
        {
            enemyCar.velocity = new Vector2(0, 0);
        }
    }
}
