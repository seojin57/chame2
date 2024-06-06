using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intogame : MonoBehaviour
{
    public void click()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void bye()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
    
}
