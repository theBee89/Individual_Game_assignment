using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_nextScene : MonoBehaviour
{
    private int nextSceneToLoad;
    public GUIStyle myStyle;
    

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneToLoad);
            
        }
    }

    //private void OnGUI()
    //{
        //GUI.Box(new Rect(10, 10, 100, 30), "Time: " + Time.time, myStyle);
        //GUI.Box(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Score: " + Player_control.score, myStyle);

    //}
}
