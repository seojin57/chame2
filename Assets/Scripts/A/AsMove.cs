using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AsMove : MonoBehaviour
{
    public float moveSpeed;
    public static float stamina = 3f;
    public Image stambar;
    Rigidbody2D rb;
    public float forceAmount;
    public Transform face;
    public static bool stunned = false;
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()

    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (stunned == false){
            Move(x, y);
        }
        
        if (Input.GetButtonDown("Jump")){
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
            stunned = true;
            Invoke("Stun5s", 4f);
        }
    }

    void Stun5s()
    {
        stunned = false;
    }
}
