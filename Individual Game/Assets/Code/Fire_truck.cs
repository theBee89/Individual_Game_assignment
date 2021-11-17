using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_truck : MonoBehaviour
{

    private float carSpeed = 8f;
    private float maxPosX = 5.5f;
    private float maxPosY = 8.6f;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -6.21f, maxPosY);

        transform.position = position;
    }
}
