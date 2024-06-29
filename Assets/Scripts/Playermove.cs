using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float speed = 3;
    
    private void Update() {
        Move();
    }
    
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        this.transform.position += moveVelocity;
    }
}
