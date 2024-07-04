using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsMove : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start() 
    {

    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
        if (x == 1)
        {
            transform.localScale = new Vector3 (2, 2, 2);
        }
        else if (x == -1)
        {
            transform.localScale = new Vector3 (-2, 2, 2);
        }
        this.transform.position += moveVelocity;
    }
}
