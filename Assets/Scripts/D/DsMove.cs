using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DsMove : MonoBehaviour
{
    public float moveSpeed;
    public static bool stunned = false;
    public static bool idle = true;
    void Start() 
    {
        
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (stunned == false){
            Move(x, y);
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

        if (x == 0 && y == 0)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }
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