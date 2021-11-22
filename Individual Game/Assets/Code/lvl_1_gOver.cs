using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl_1_gOver : MonoBehaviour
{
    public GameObject player_control;
    private bool playerDestroyed = false;


    // Update is called once per frame
    void Update()
    {
        
        if(Player_control.destroyed == true)
        {
            StartCoroutine(loadGameOver());
            Player_control.destroyed = false;
            
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
