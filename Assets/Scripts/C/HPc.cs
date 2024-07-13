using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HPc : MonoBehaviour
{
    public GameObject bar;
    public TextMeshProUGUI text;
    public static float HP = 1900;
    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP/1900;

        text.text = HP.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "b500")
        {
            HP -= 500;
        }
        if (other.tag == "b1300")
        {
            HP -= 1300;
            BsAttack1.specialAttack = false;
        }
        if (other.tag == "p150")
        {
            HP -= 150;
        }
    }
}