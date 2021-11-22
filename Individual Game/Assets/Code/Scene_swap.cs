using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_swap : MonoBehaviour
{

    private int nextSceneToLoad;
    private int previousScene;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        previousScene = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(previousScene);
        }
    }
}
