using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar HealthBar;
    public Rigidbody2D car;

    public GameObject ambulance;

    Ambulance_control ambulance_Control;

    public float carSpeed = 6f;
    private float maxPosX = 5.5f;
    private float maxPosY = 8.6f;

    public bool isCollidingTop = false;
    public bool isCollidingSide = false;

    Vector3 position;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        ambulance_Control = GameObject.Find("Ambulance").GetComponent<Ambulance_control>();
        position = transform.position;
        audio = GetComponent<AudioSource>();
        audio.loop = true;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -6.21f, maxPosY);

        transform.position = position;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            //ambulance_Control = GetComponent<Ambulance_control>();
            ambulance_Control.TakeDamage(20);

            HealthBar.SetHealth(currentHealth);
        }
    }

    private void FixedUpdate()
    {
        

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.tag == "Ambulance" && position.y > collision.gameObject.transform.position.y)
       // {
          //  isCollidingSide = false;
            //position.y += 1f;

            //transform.position = position;
        //}

        //if (collision.gameObject.tag == "Ambulance" && position.x > collision.gameObject.transform.position.x && position.y == collision.gameObject.transform.position.y)
        //{
          //  position.x += 0.5f;
            //transform.position = position;
        //}
        //if (collision.gameObject.tag == "Ambulance" && position.x < collision.gameObject.transform.position.x && position.y == collision.gameObject.transform.position.y)
        //{
          //  position.x -= 0.5f;
           // transform.position = position;
        //}

        //if(collision.gameObject.tag == "Road1")
        //{
          //  Debug.Log("Wall Hit");
            //position.y += Input.GetAxis("Vertical") * 0f * Time.deltaTime;
            //carSpeed = 0;

            //gameObject.transform.Translate(0f, 0f, 0f);
        //}
    }
}





