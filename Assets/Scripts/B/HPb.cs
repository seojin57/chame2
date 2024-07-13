using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HPb : MonoBehaviour
{
    public GameObject bar;
    public GameObject fury;
    public TextMeshProUGUI text;
    public static float HP = 3200;

    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP/3200;
        if (HP/3200 <= 0.2)
        {
            fury.GetComponent<Image>().color = new Color32(255, 0, 77, 255);
        }
        if (HP/3200 > 0.2 && HP/3200 <= 0.6)
        {
            fury.GetComponent<Image>().color = new Color32(200, 0, 77, 255);
        }
        if (HP/3200 > 0.6)
        {
            fury.GetComponent<Image>().color = new Color32(145, 0, 77, 255);
        }
        text.text = HP.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "p150")
        {
            HP -= 150;
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
}