using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winners_scene : MonoBehaviour
{

    public GUIStyle myStyle;

    

    private void OnGUI()
    {
        
        GUI.Box(new Rect(Screen.width/2.5f, Screen.height/2, 100, 30), "Final Score: " + Player_control.score, myStyle);
    }
}
