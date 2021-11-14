using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_control : MonoBehaviour
{
    private int nextSceneToLoad;

    public int maxHealth = 100;
    public int currentHealth;
    public int isFire = 0;
    public bool callFire = false;

    public int lives = 3;

    public HealthBar HealthBar;
    public Rigidbody2D car;
    public GameObject fireLight;
    public GameObject e;
    public GameObject explosion;

    public Transform damaged;
    public Rigidbody2D fireRb;

    public GameObject ambulance;

    Ambulance_control ambulance_Control;

    public float carSpeed = 8f;
    private float maxPosX = 5.5f;
    private float maxPosY = 8.6f;
    public Vector2 playerPos;

    public bool isCollidingTop = false;
    public bool isCollidingSide = false;

    Vector3 position;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //ambulance_Control = GameObject.FindGameObjectWithTag("Ambulance").GetComponent<Ambulance_control>();
        //fire.SetActive(false);
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        position = transform.position;
        audio = GetComponent<AudioSource>();
        audio.loop = true;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth >= 100)
        {
            currentHealth = 100;
        }
        if(lives == 0)
        {
            Destroy(gameObject);
        }
        

        
        if(e != null)
        {
            e.transform.position = damaged.transform.position;
        }  
        
        

        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
         

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -6.21f, maxPosY);

        transform.position = position;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            

            HealthBar.SetHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            gainHealth(20);


            HealthBar.SetHealth(currentHealth);
        }
    }

   

   

    void gainHealth(int heal)
    {
        currentHealth += heal;
        HealthBar.SetHealth(currentHealth);
        if(currentHealth >= 50)
        {
            Destroy(e);
            isFire = 0;
        } 
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        if(currentHealth <= 50 && isFire == 0)
        {
            e = Instantiate(fireLight, damaged.position, damaged.rotation);
            e.transform.position = damaged.transform.position;
            isFire = 1;
        }
        if (currentHealth <= 10)
        {
            Destroy(e);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(20);

            GameObject e = Instantiate(explosion);
            e.transform.position = transform.position;
            Destroy(collision.gameObject);
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}





