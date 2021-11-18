using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_truck : MonoBehaviour
{

    private float carSpeed = 8f;
    private float maxPosX = 5.5f;
    private float maxPosY = 8.6f;

    public int isFire = 0;

    public GameObject e;

    public GameObject fireLight;

    public Transform damaged;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar HealthBar;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

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

        if (currentHealth <= 0)
        {
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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        if (currentHealth <= 50 && isFire == 0)
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
        if(collision.gameObject.name == "Fire_car(Clone)")
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
        }
    }
}
