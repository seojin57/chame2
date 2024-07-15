using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AsMove1 : MonoBehaviour
{
    public float moveSpeed;
    public static float stamina = 3f;
    public Image stambar;
    Rigidbody2D rb;
    public float forceAmount;
    public Transform face;
    public static bool stunned = false;
    public bool slow = false;
    public bool dstunned = false;
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()

    {
        if (slow)
        {
            moveSpeed = 1.5f;
        }
        if (!slow)
        {
            moveSpeed = 4f;
        }

        float x = Input.GetAxisRaw("Horizontal2");
        float y = Input.GetAxisRaw("Vertical2");
        if (stunned == false){
            Move(x, y);
        }
        
        if (Input.GetButtonDown("Jump2")){
            Dash(x, y);
        }

        stambar.GetComponent<Image>().fillAmount = stamina / 3;
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

    void Dash(float x, float y)
    {
        if (stunned == false)
        {
        if (stamina >= 1)
        {
            if (x == 1 && y == 0){
                rb.AddForce(Vector2.right * forceAmount, ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == 1 && y == 1){
                rb.AddForce(new Vector2(forceAmount/2, forceAmount/2), ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == 1 && y == -1){
                rb.AddForce(new Vector2(forceAmount/2, -1 * forceAmount/2), ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == 0 && y == 1){
                rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == 0 && y == -1){
                rb.AddForce(Vector2.down * forceAmount, ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == -1 && y == 0){
                rb.AddForce(Vector2.left * forceAmount, ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == -1 && y == 1){
                rb.AddForce(new Vector2(-forceAmount/2, forceAmount/2), ForceMode2D.Impulse);
                stamina -= 1;
                }
            else if (x == -1 && y == -1){
                rb.AddForce(new Vector2(-forceAmount/2, -forceAmount/2), ForceMode2D.Impulse);
                stamina -= 1;
                }
        }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "b500")
        {
            rb.AddForce(-face.forward * forceAmount, ForceMode2D.Impulse);
        }
        if (other.tag == "bStun")
        {
            HPa.HP -= 700;
            stunned = true;
            Invoke("Stun5s", 4f);
        }
        if (other.tag == "dd100")
        {
            slow = true;
            Invoke("Slow5s", 4f);
        }
        if (other.tag == "d100" && !dstunned)
        {
            HPa.HP -= 100;
            stunned = true;
            dstunned = true;
            Invoke("Stun5s", 4f);
            Invoke("dstunEnd", 40f);
        }
    }

    void Stun5s()
    {
        stunned = false;
    }

    void Slow5s()
    {
        slow = false;
    }

    void dstunEnd()
    {
        dstunned = false;
    }
}
