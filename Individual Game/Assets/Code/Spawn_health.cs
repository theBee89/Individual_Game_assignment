using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_health : MonoBehaviour
{

    public Rigidbody2D heart;
    public Transform ambulance;
    public GameObject ambulanceHelp;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHeart", 60,60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnHeart()
    {
        Rigidbody2D heartInstance;
        heartInstance = Instantiate(heart, ambulance.position,ambulanceHelp.transform.rotation);
        heartInstance.name = "Heart(Clone)";
        
    }
}
