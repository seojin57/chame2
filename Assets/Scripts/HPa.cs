using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPa : MonoBehaviour
{
    public GameObject bar;
    public static float HP = 100;
    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP/100;
    }
}