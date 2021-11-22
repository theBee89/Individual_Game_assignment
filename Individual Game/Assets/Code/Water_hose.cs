using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_hose : MonoBehaviour
{

    public Transform weapon;

    public GameObject bulletPrefab;

    public bool canShoot = true;

    public float timer;
    

    

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKey(KeyCode.Space))
            {
            shoot();
            

        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
        
        

        
   }

    void shoot()
    {
        
        Instantiate(bulletPrefab, weapon.position, weapon.rotation);
        
        

    }
}
