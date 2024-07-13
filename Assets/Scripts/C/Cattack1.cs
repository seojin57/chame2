using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cattack1 : MonoBehaviour
{
    public GameObject slash1;
    public GameObject slash2;
    public Sprite invin;
    public Sprite Ninvin;
    public bool onetwo;
    public bool onAttacking = false;
    public float invCool = 8;
    public GameObject invbar;
    BoxCollider2D coll;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        StartCoroutine(hideCool());
        coll = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        onetwo = true;
        slash1.SetActive(false);
        slash2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump2") && invCool >= 8 && CsMove1.stunned == false)
        {
            CsMove1.stunned = true;
            invCool = 0;
            coll.enabled = false;
            spriteRenderer.sprite = invin;
            Invoke("Noinv", 0.5f);
        }

        if (Input.GetButtonDown("Fire12") && !onAttacking && CsMove1.stunned == false)
        {
            if (onetwo == true){
                Invoke("S1", 0.2f);
                onetwo = false;
                onAttacking = true;
            }
            else if (onetwo == false){
                Invoke("S2", 0.2f);
                onetwo = true;
                onAttacking = true;
            }
        }

        invbar.GetComponent<Image>().fillAmount = invCool / 8;
    }

    void Noinv()
    {
        coll.enabled = true;
        CsMove1.stunned = false;
        spriteRenderer.sprite = Ninvin;
    }

    void S1()
    {
        slash1.SetActive(true);
        Invoke("S1End", 0.3f);
    }

    void S1End()
    {
        slash1.SetActive(false);
        onAttacking = false;
    }

    void S2()
    {
        slash2.SetActive(true);
        Invoke("S2End", 0.3f);
    }

    void S2End()
    {
        slash2.SetActive(false);
        Invoke("Cooldown", 3.4f);
    }

    void Cooldown()
    {
        onAttacking = false;
    }

    IEnumerator hideCool()
    {   
        yield return null;
        while (true)
        {
            invCool += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
