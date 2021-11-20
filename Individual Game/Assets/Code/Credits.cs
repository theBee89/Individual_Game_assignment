using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    private float timer;

    

    // Update is called once per frame
    void Update()
    {
        timer += 1.0f * Time.deltaTime;

        if(timer >= 5f)
        {
            SceneManager.LoadScene("main_menu");
        }
    }
}
