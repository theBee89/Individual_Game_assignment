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

    public static int missFire;

    public GUIStyle myStyle;

    public int isFire = 0;

    public GameObject e;
    public GameObject explosion;
    public Transform fireTruck;

    public GameObject fireLight;

    public Transform damaged;

    public int maxHealth = 100;
    public static int currentHealth;

    public HealthBar HealthBar;

    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        


        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        time = 0;
        position = transform.position;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -8f, maxPosY);

        transform.position = position;

        if (currentHealth <= 0)
        {
            Instantiate(explosion, fireTruck.position, fireTruck.rotation);
            Destroy(gameObject);
        }

        if (e != null)
        {
            e.transform.position = damaged.transform.position;
        }

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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        if (currentHealth <= 50 && isFire == 0)
        {
            e = Instantiate(fireLight, damaged.position, damaged.rotation);
            e.transform.position = damaged.transform.position;
            isFire = 1;
        }
        if (currentHealth < 10)
        {
            Destroy(e);
        }
    }

    void gainHealth(int heal)
    {
        currentHealth += heal;
        HealthBar.SetHealth(currentHealth);
        if (currentHealth >= 50)
        {
            Destroy(e);
            isFire = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Fire_car(Clone)")
        {
            Destroy(collision.gameObject);
            TakeDamage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            
            StartCoroutine(loadNextScene());
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
        GUI.Box(new Rect(10, 50, 100, 30), "Score: " + Player_control.score, myStyle);

    }
}
