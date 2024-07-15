using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BsMove1 : MonoBehaviour
{
    public float moveSpeed;
    public static bool stunned = false;
    public bool slow = false;
    public bool dstunned = false;
    // Start is called before the first frame update
    void Update()
    {
        if (stunned == false){
            Move();
        }
    }

    void Move()
    {
        if (slow)
        {
            moveSpeed = 1.5f;
        }
        if (!slow)
        {
            moveSpeed = 4f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "dd100")
        {
            slow = true;
            Invoke("Slow5s", 4f);
        }
        if (other.tag == "d100" && !dstunned)
        {
            HPb.HP -= 100;
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
