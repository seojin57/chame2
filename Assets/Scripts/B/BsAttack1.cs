using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BsAttack1 : MonoBehaviour
{
    public Transform target;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject Boom;
    public bool attacking = false;
    public bool OnUlt = true;
    public static bool specialAttack = false;
    public bool specialAttacked = false;
    public bool zichim = false;
    public bool zichim1 = false;
    public float aSpeed = 1.2f;
    public float aReroad = 3f;
    void Start()
    {
        sword1.SetActive(false);
        sword2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HPb.HP / 3200 <= 0.6 && !specialAttack && !zichim)
        {
            aSpeed = 0.2f;
            aReroad = 2f;
        }
        else if (HPb.HP / 3200 > 0.6 && !specialAttack && !zichim)
        {
            aSpeed = 1.2f;
            aReroad = 3f;
        }

        if (specialAttacked && !specialAttack && zichim1 && zichim)
        {
            zichim1 = false;
            aSpeed = 1.7f;
            aReroad = 2f;
            Invoke("Imokay", 6f);
        }

        if (HPb.HP / 3200 <= 0.2 && !specialAttacked)
        {
            specialAttacked = true;
            specialAttack = true;
            zichim = true;
            zichim1 = true;
            aSpeed = 0.2f;
            aReroad = 0.6f;
        }

        if (Input.GetButtonDown("Fire12") && !attacking && !specialAttack)
        {
            attacking = true;
            Invoke("Swing", aSpeed);
            Invoke("Cooldown", aReroad);
        }

        if (Input.GetButtonDown("Fire12") && !attacking && specialAttack)
        {
            attacking = true;
            Invoke("Swing1", aSpeed);
            Invoke("Cooldown", aReroad);
        }

        if (Input.GetButtonDown("Fire22") && OnUlt)
        {
            OnUlt = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Vector3 pos = target.position;
            StartCoroutine("Ult");
            Invoke("Ultend", 1f);
            Invoke("UltCool", 80f);
        }
    }

    void Swing()
    {
        sword1.SetActive(true);
        Invoke("SwingEnd", 0.3f);
    }

    void Swing1()
    {
        sword2.SetActive(true);
        Invoke("SwingEnd2", 0.3f);
    }

    void SwingEnd()
    {
        sword1.SetActive(false);
    }

    void SwingEnd2()
    {
        sword2.SetActive(false);
    }

    void Cooldown()
    {
        attacking = false;
    }

    IEnumerator Ult()
    {
        Vector3 where = target.position;
        while (true) 
        {
        this.transform.position = Vector3.Lerp(transform.position, where, 0.01f);
        
        yield return null;
        }
    }
    
    void Ultend()
    {
        StopCoroutine("Ult");
        Boom.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void UltCool()
    {
        OnUlt = true;
    }

    void Imokay()
    {
        zichim = false;
    }
}
