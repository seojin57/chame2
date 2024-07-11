using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HPa : MonoBehaviour
{
    public GameObject bar;
    public TextMeshProUGUI text;
    public static float HP = 3500;
    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP/100;

        text.text = HP.ToString();
    }
}