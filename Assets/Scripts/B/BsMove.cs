using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsMove1 : MonoBehaviour
{
    public float moveSpeed;
    public static bool stunned = false;
    // Start is called before the first frame update
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal2");
        float y = Input.GetAxisRaw("Vertical2");
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
}
