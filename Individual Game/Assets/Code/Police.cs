using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Police : MonoBehaviour
{
    private int nextSceneToLoad;
    private float carSpeed = 8f;
    private float maxPosX = 5.5f;
    private float maxPosY = 8.6f;
    private float time;

    public static int wrongVehicle = 0;

    public static int missFire;

    public GUIStyle myStyle;

    
    public GameObject fireTest;
    public GameObject explosion;
    public Transform fireTruck;


    public static bool destroyed;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar HealthBar;

    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {


        destroyed = false;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; // Sets the next scene to nextSceneToLoad variable

        time = 0;
        position = transform.position;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime; // Handles movement 
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX); // Keeps player within play area
        position.y = Mathf.Clamp(position.y, -8f, maxPosY);

        transform.position = position;

        if (currentHealth <= 0)
        {
            Instantiate(explosion, fireTruck.position, fireTruck.rotation);
            Destroy(gameObject);
            destroyed = true; // Triggers Game over scene load once healthbar is empty
        }

        if (currentHealth <= 50)
        {
            fireTest.SetActive(true); // Sets car on fire when health is below 50

        }
        else
        {
            fireTest.SetActive(false); // Fire goes out if health is above 50
        }

        

        if (Input.GetButtonDown("Fire1")) // Used for testing purposes
        {
            TakeDamage(20);


            HealthBar.SetHealth(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.B)) // Used for testing purposes
        {
            gainHealth(20);


            HealthBar.SetHealth(currentHealth);
        }
        if(currentHealth > 100) // Makes sure health cant go above 100
        {
            currentHealth = 100;
        }

        if (wrongVehicle == 1) // If the player shoots an emergency vehicle this will damage the players health
        {
            TakeDamage(10);
            wrongVehicle = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        
    }

    void gainHealth(int heal)
    {
        currentHealth += heal;
        HealthBar.SetHealth(currentHealth);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(collision.gameObject.tag == "lvl_3" || collision.gameObject.tag == "lvl3_car")
        {
            TakeDamage(10);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish") // Triggers end of level
        {
            
            StartCoroutine(loadNextScene());
        }

        if (collision.gameObject.tag == "Bomb2")
        {
            TakeDamage(5);
        }
    }

    private void toNextScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
       
    }

    IEnumerator loadNextScene()
    {

        yield return new WaitForSeconds(3.0f);
        toNextScene();


    }



    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 30), "Time: " + time, myStyle);
        GUI.Box(new Rect(10, 70, 100, 30), "Score: " + Player_control.score, myStyle);

    }
}
