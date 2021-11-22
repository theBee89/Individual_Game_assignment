using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public Transform car;
    public GameObject fireCar;



    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "missFire")
        {
            Debug.Log("Collision detected");
            Fire_truck.missFire = 1;
            
            
        }
    }

   
}
