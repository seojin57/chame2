using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    public void Openset()
    {
        panel.SetActive(true);
    }

    public void Closeset()
    {
        panel.SetActive(false);
    }
}
