using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DsBullet1 : MonoBehaviour
{
    public bool onIdle;
    public float bulletSpeed = 20;
    void Start()
    {
        onIdle = DsAttack.IsIdle;
        if (onIdle)
        {
            bulletSpeed += 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
