using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_fireCar : MonoBehaviour
{

    private float maxTime = 8f;
    private float minTime = 2f;

    private float spawnTime;
    private float time;

    private float timer;

    public GameObject fireCar;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1.0f * Time.deltaTime;

        if(timer >= 60f)
        {
            maxTime = 5;
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }

    void SpawnObject()
    {
        
        time = minTime;
        Instantiate(fireCar, new Vector3(Random.Range(-4.9f, 4.9f), 12.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
        // Spawns fireCar at random intervals within a certain timeframe


    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish") // Destroys the spawn fireCar object once the finish line is called
        {
            Destroy(gameObject);
        }
    }
}
