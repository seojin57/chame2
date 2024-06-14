using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pickchoice : MonoBehaviour
{
    private string choice;
    public string player1;
    public Text text;
    public Component firstscript;
    void Start()
    {
        firstscript = gameObject.GetComponent<pickchoice>();
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            choice = "sniper";
        }
        if (Input.GetKeyDown("2"))
        {
            choice = "fighter";
        }
        if (Input.GetKeyDown("3"))
        {
            choice = "wizard";
        }
        if (Input.GetKeyDown("4"))
        {
            choice = "berserker";
        }
        if (Input.GetKeyDown("enter"))
        {
            player1 = choice;
            firstscript.enabled = false;
        }
        
        text.text = choice;
        
    }


}