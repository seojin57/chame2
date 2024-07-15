using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSystem : MonoBehaviour
{
    public Image P1bar;
    public Image P2bar;
    public bool sung = false;

    void Start()
    {
        Invoke("win", 1f);
    }

    void win()
    {
        sung = true;
    }

    void Update()
    {
        if (sung){
            if (P1bar.GetComponent<Image>().fillAmount <= 0)
            {
                SceneManager.LoadScene("Player2Win");
            }
            if (P2bar.GetComponent<Image>().fillAmount <= 0)
            {
                
                SceneManager.LoadScene("Player1Win");
            }
        }
        
    }
}
