using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsMove : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start() 
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
            playerSpriteRenderer.flipX = false;
        }
        else if (x == -1)
        {
            playerSpriteRenderer.flipX = true;
        }
        this.transform.position += moveVelocity;
    }
}
