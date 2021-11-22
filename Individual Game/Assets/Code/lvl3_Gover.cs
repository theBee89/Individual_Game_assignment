using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl3_Gover : MonoBehaviour
{

    public GameObject player_control;
    private bool playerDestroyed = false;

    

    // Update is called once per frame
    void Update()
    {


        if (Police.destroyed == true)
        {
            StartCoroutine(loadGameOver());
            playerDestroyed = false;
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
