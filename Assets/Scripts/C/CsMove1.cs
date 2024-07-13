using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CsMove1 : MonoBehaviour
{
    public float moveSpeed;
    public static bool stunned = false;
    public bool onUlt = true;
    public int wasd;
    public float forceAmount;
    Rigidbody2D rb;
    public GameObject UltHit;
    void Start() 
    {
        UltHit.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal2");
        float y = Input.GetAxisRaw("Vertical2");
        if (x == 0 && y == 1)
        {
            wasd = 1;
        }
        if (x == -1 && y == 0)
        {
            wasd = 2;
        }
        if (x == 0 && y == -1)
        {
            wasd = 3;
        }
        if (x == 1 && y == 0)
        {
            wasd = 4;
        }

        if (stunned == false){
            Move(x, y);
        }

        if (Input.GetButtonDown("Fire22") && onUlt && wasd != null && !stunned)
        {
            stunned = true;
            onUlt = false;
            Invoke("Shoong", 2);
            Invoke("UltEnd", 2.4f);
            Invoke("UltCool", 80);
        }
    }

    void Move(float x, float y)
    {
        Vector3 moveVelocity = new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
        if (x == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        this.transform.position += moveVelocity;
    }
    void Shoong()
    {
        UltHit.SetActive(true);
        if (wasd == 1)
        {
            rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
        }
        if (wasd == 2)
        {
            rb.AddForce(Vector2.left * forceAmount, ForceMode2D.Impulse);
        }
        if (wasd == 3)
        {
            rb.AddForce(Vector2.down * forceAmount, ForceMode2D.Impulse);
        }
        if (wasd == 4)
        {
            rb.AddForce(Vector2.right * forceAmount, ForceMode2D.Impulse);
        }
    }

    void UltEnd()
    {
        stunned = false;
        UltHit.SetActive(false);
    }

    void UltCool()
    {
        onUlt = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bStun")
        {
            stunned = true;
            Invoke("Stun5s", 4f);
        }
    }

    void Stun5s()
    {
        stunned = false;
    }
}