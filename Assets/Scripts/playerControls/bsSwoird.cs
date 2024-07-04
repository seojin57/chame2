using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bsSwoird : MonoBehaviour
{
    public GameObject attack1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Invoke("A1", 0.5f);
        }
    }

    void A1()
    {
        attack1.SetActive(true);
    }
}
