using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsAttack1 : MonoBehaviour
{
    public GameObject fist1;
    public GameObject fist2;
    public bool running = false;
    public bool OnUlt = true;
    void Start()
    {
        fist1.SetActive(false);
        fist2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && running == false && AsMove.stunned == false)
        {
            StartCoroutine(Attack1());
            Invoke("Stop1", 0.8f);
            Invoke("RunningFalse", 1f);
        }

        if (Input.GetButtonDown("Fire2") && OnUlt == true && AsMove.stunned == false)
        {
            Invoke("StartUlt", 0);
            Invoke("EndUlt", 3f);
        }
    }

    IEnumerator Attack1()
    {
        running = true;
        fist1.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        fist2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        fist1.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
    }

    void Stop1()
    {
        fist2.SetActive(false);
        StopCoroutine(Attack1());
    }

    void RunningFalse()
    {
        running = false;
    }

    void StartUlt()
    {
        AsMove.stamina = 1000;
        OnUlt = false;
        Invoke("Recharge", 40f);
    }

    void EndUlt()
    {
        AsMove.stamina = 3;
    }

    void Recharge()
    {
        OnUlt = true;
    }
}
