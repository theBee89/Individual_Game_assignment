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
    //public GameObject e;
    public GameObject explosion;

    public GameObject fireTest;

    public Transform damaged;
    public Transform player;
    public Rigidbody2D fireRb;

    public GameObject ambulance;

    Ambulance_control ambulance_Control;

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
            fireTest.SetActive(true);

        }
        else
        {
            fireTest.SetActive(false);
        }
        
        

        
        //if(e != null)
        //{
          //  e.transform.position = damaged.transform.position;
        //}  
        
        

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            StartCoroutine(loadGameOver());
            //lives = 1;
        }
        if(currentHealth <= 0)
        {
            destroyed = true;
            Instantiate(explosion, player.position, player.rotation);
            Destroy(gameObject);
        }
         

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -6.21f, maxPosY);

        transform.position = position;


        if (Input.GetButtonDown("Fire1"))
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

    IEnumerator loadGameOver()
    {

        yield return new WaitForSeconds(3.0f);
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
        //if(currentHealth >= 50)
        //{
            
          //  Destroy(e);
            //isFire = 0;
        //} 
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        //if(currentHealth <= 50 && isFire == 0)
        //{
            
            //e = Instantiate(fireLight, damaged.position, damaged.rotation);
            //e.transform.position = damaged.transform.position;
          //  isFire = 1;
        //}
        //if (currentHealth <= 10)
        //{
          //  Destroy(e);
        //}
    }

   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            score += (2000 * lives);
            StartCoroutine(loadNextScene());
        }

        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(20);

            Destroy(collision.gameObject);
            //GameObject e = Instantiate(explosion);
            //e.transform.position = transform.position;

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

    IEnumerator loadNextScene()
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





