using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HPa : MonoBehaviour
{
    public GameObject bar;
    public TextMeshProUGUI text;
    public static float HP = 3000;
    void Start()
    {
        HP = 3000;
    }
    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP/3000;

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
        if (other.tag == "c500")
        {
            HP -= 500;
        }
        if (other.tag == "c1000")
        {
            HP -= 1000;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "d400")
        {
            HP -= 400;
        }
    }
}