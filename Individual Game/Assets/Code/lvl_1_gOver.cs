using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl_1_gOver : MonoBehaviour
{
    public GameObject player_control;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_control = GameObject.Find("Player_car1");
        Player_control player_Control = player_control.GetComponent<Player_control>();

        if (Player_control.currentHealth <= 0)
        {

            StartCoroutine(loadGameOver());

        }
        if(player_Control.lives == 0)
        {
            StartCoroutine(loadGameOver());
        }


    }

    private void toNextScene()
    {
        
        SceneManager.LoadScene("Game_Over");
    }

    IEnumerator loadGameOver()
    {

        yield return new WaitForSeconds(3.0f);
        toNextScene();


    }
}
