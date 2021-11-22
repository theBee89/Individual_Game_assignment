using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_gameOver : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Fire_truck.destroyed == true)
        {
            
            StartCoroutine(loadGameOver());
            Fire_truck.destroyed = false;
            
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
