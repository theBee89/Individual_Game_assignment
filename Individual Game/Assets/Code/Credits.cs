using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    private float timer;
    public GUIStyle myStyle;
    string sceneName;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }


    // Update is called once per frame
    void Update()
    {
        timer += 1.0f * Time.deltaTime;

        if(timer >= 5f)
        {
            SceneManager.LoadScene("main_menu");
        }
    }

    private void OnGUI()
    {
        if(sceneName == "Game_Over")
        {
            GUI.Box(new Rect(Screen.width / 2.3f, Screen.height / 2.3f, 100, 30), "Final Score: " + Player_control.score, myStyle);
        }
        
    }
}
