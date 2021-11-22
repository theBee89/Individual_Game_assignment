using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBomb : MonoBehaviour
{
    private float maxTime = 5f;
    private float minTime = 2f;

    private float spawnTime;
    private float time;

    public GameObject firePoint;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        time = minTime;
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
            Instantiate(bomb, firePoint.transform.position, bomb.transform.rotation);
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
