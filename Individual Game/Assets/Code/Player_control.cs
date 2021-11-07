using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    public float carSpeed;
    private float maxPosX = 5.5f;
    private float maxPosY = 8.6f;

    Vector3 position;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        audio = GetComponent<AudioSource>();
        audio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -maxPosY, maxPosY);

        transform.position = position;
    }
}





