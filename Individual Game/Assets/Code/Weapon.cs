using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform weapon;
    
    public GameObject bulletPrefab;
    
    public bool canShoot = true;

    public float timer;

    

    // Update is called once per frame
    void Update()
    {
        // Adds a delay to shooting
        timer += 1.0f * Time.deltaTime;
        if(timer >= 0.4f)
        {
            canShoot = true;
        }
        if(canShoot == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shoot();
            }
        }
        
    }

    void shoot() // Shoots bullets whenever space is pressed
    {
        canShoot = false;
        timer = 0f;
        Instantiate(bulletPrefab, weapon.position, Quaternion.Euler(0,0,90));
        
       

    }
}
