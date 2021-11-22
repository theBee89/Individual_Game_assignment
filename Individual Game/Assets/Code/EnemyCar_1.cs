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
        if(timer >= 3f && timer <= 5f && isMoving) // Moves cars onto screen at beginning of level
        {
            enemyCar.velocity = new Vector2(0, 0);
            isMoving = false;
        }

        if(timer >= 60f && !isMoving) // Brings enemy cars closer to player halfway through the level
        {
            enemyCar.velocity = new Vector2(0, -speed);

        }
        if(timer >= 62f && !isMoving)
        {
            enemyCar.velocity = new Vector2(0, 0);
            isMoving = true;
        }

        if(enemyCar.velocity.y > 0)
        {
            destroyTime += 1.0f * Time.deltaTime;
        }
        if(destroyTime >= 4)
        {
            DestroyCar();
        }

        if(timer >= 40)
        {
            maxTime = 8;
        }

        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time >= spawnTime) // Spawns bombs when time is greater than or equal to spawntime, then sets random time for the next call
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
                enemyCar.velocity = new Vector2(0, 2f); // Cars move away once the finish line appears
            
            
            
        }
    }
    private void DestroyCar()
    {
        Destroy(gameObject);
    }
}
