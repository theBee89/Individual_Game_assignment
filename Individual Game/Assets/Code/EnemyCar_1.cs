using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar_1 : MonoBehaviour
{
    public GameObject bomb;
    public Rigidbody2D enemyCar;
    public Transform firePoint;

    private float maxTime = 15f;
    private float minTime = 2f;

    private float time;

    private float spawnTime;

    private float speed = 2f;
    private float timer;

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
        if(timer >= 3f)
        {
            enemyCar.velocity = new Vector2(0, 0);
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
        time = minTime;
        Instantiate(bomb, firePoint.position, bomb.transform.rotation);
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
