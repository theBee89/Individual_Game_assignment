using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_traffic : MonoBehaviour
{
    private float maxTime = 4f;
    private float minTime = 2f;


    private float spawnTime;
    private float time;

    public GameObject police;
    public GameObject ambulance;
    public GameObject fireTruck;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

   

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime) // Sets how often the spawnTraffic method is called
        {
            SpawnObject();
            SetRandomTime();
        }

    }

    void SpawnObject()
    {

        time = minTime;
        int value = Random.Range(1, 8);
        Debug.Log(value);

        switch (value) // Depending on the value of the value variable, the switch statement will spawn a different type of vehicle everytime it is called
        {
            case 1:
                Instantiate(car, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;
            case 2:
                Instantiate(ambulance, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;
            case 3:
                Instantiate(police, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;
            case 4:
                Instantiate(fireTruck, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                break;
            case 5:
                Instantiate(car, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;
            case 6:
                Instantiate(car, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;
            case 7:
                Instantiate(car, new Vector3(Random.Range(-4.9f, 4.9f), 13.5f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                break;


        }
        


    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish") // Destroys traffic spawner once finish line is called
        {
            Destroy(gameObject);
        }
    }


}
