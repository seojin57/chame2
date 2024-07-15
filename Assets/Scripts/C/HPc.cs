using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HPc : MonoBehaviour
{
    public GameObject bar;
    public TextMeshProUGUI text;
    public static float HP = 2800;

    void Start()
    {
        HP = 2800;
    }
    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP/2800;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "d400")
        {
            HP -= 400;
        }
    }
}