using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar_1 : MonoBehaviour
{
    public GameObject bomb;
    public Rigidbody2D enemyCar;
    public Transform firePoint;

    private float maxTime = 12f;
    private float minTime = 2f;

    private float time;
    private float destroyTime;

    private float spawnTime;

    private float speed = 2f;
    private float timer;

    public bool isMoving = true; 

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        time = minTime;
        enemyCar = this.GetComponent<Rigidbody2D>();
        enemyCar.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1.0f * Time.deltaTime;
        if(timer >= 3f && isMoving)
        {
            enemyCar.velocity = new Vector2(0, 0);
            isMoving = false;
        }

        if(enemyCar.velocity.y > 0)
        {
            destroyTime += 1.0f * Time.deltaTime;
        }
        if(destroyTime >= 4)
        {
            DestroyCar();
        }

        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }
        
    }

    void SpawnObject()
    {
        if(enemyCar.velocity.y == 0)
        {
            time = minTime;
            Instantiate(bomb, firePoint.position, bomb.transform.rotation);
        }
        
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            
                enemyCar = this.GetComponent<Rigidbody2D>();
                enemyCar.velocity = new Vector2(0, 2f);
            
            
            
        }
    }
    private void DestroyCar()
    {
        Destroy(gameObject);
    }
}
