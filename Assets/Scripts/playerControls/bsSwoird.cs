using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bsSwoird : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x == 1)
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (x == -1)
        {
            playerSpriteRenderer.flipX = true;
        }
    }
}
