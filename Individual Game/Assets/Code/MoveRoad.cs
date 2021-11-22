using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float speed;
    Vector2 offset;

    

    // Update is called once per frame
    void Update()
    {
        
            // Keeps the background road repeating itself
            offset = new Vector2(0, Time.time * speed);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        
        

    }
}
