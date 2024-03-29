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
    private float time;

    public static bool destroyed;

    

    public static int score;
    public GUIStyle myStyle;

    public int lives = 3;

    public HealthBar HealthBar;
    public Rigidbody2D car;
    public GameObject fireLight;
    
    public GameObject explosion;

    public GameObject fireTest;

    public Transform damaged;
    public Transform player;
    public Rigidbody2D fireRb;

    public GameObject ambulance;

    

    private float carSpeed = 8f;
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
        destroyed = false;
        score = 0;
        time = 0;
     
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
        time += Time.deltaTime;
        if(currentHealth >= 100) 
        {
            currentHealth = 100;
        }

        if(currentHealth <= 50)
        {
            fireTest.SetActive(true); // Sets car on fire when health is below 50

        }
        else
        {
            fireTest.SetActive(false); // Fire goes out if health is above 50
        }
        
        
        if (lives <= 0) // Lives deduct in level 1 whenever an ambulance is destroyed and game over function is called when all 3 are destroyed
        {
            Debug.Log("Game Over");
            StartCoroutine(loadGameOver());
            
        }
        if(currentHealth <= 0) // Once health is empty creates explosion and destroys the car
        {
            destroyed = true;
            Instantiate(explosion, player.position, player.rotation);
            Destroy(gameObject);
        }
         

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime; // Controls player movement
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX); // Keeps player within the bounds of the playing area
        position.y = Mathf.Clamp(position.y, -6.21f, maxPosY);

        transform.position = position;


        if (Input.GetButtonDown("Fire1"))  // Used for testing purposes 
        {
            TakeDamage(20);
            

            HealthBar.SetHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.B)) // Used for testing purposes
        {
            gainHealth(20);


            HealthBar.SetHealth(currentHealth);
        }

       
    }

    IEnumerator loadGameOver()
    {

        yield return new WaitForSeconds(3.0f); // After 3 seconds calls to game over screne function once players health is 0
        toGoScene();


    }

    private void toGoScene()
    {

        SceneManager.LoadScene("Game_Over");
    }





    void gainHealth(int heal)
    {
        currentHealth += heal;
        HealthBar.SetHealth(currentHealth); 
         
    }
    void TakeDamage(int damage) // Handles damage from collisions
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth); // Keeps the healthbar set to current health int

    }

   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish") // Triggers the end of the level
        {
            score += (2000 * lives);
            StartCoroutine(loadNextScene());
        }

        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(20);

            Destroy(collision.gameObject);
           

        }

        if (collision.gameObject.name == "Heart(Clone)")
        {
            gainHealth(20);
            Destroy(collision.gameObject);
        }
    }

    private void toNextScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
       
    }

    IEnumerator loadNextScene() // Once this is called it waits 3 seconds before executing the toNextScene() function
    {

        yield return new WaitForSeconds(3.0f);
        toNextScene();


    }



    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 30), "Time: " + time, myStyle);
        GUI.Box(new Rect(10, 70, 100, 30), "Score: " + score, myStyle);
       
    }
}





