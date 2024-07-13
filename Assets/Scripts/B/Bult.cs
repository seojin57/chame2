using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bult : MonoBehaviour
{
    private CircleCollider2D collider;
    public Transform B;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.radius = 0.1f;
        gameObject.SetActive(false);
    }
    void OnEnable() 
    {
        this.transform.position = B.position;
        StartCoroutine("exp");
    }
    
    IEnumerator exp()
    {
        yield return null;
        while (collider.radius < 3f)
        {
            collider.radius += 0.15f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Invoke("boomEnd", 0f);
    }

    void boomEnd()
    {
        StopCoroutine("exp");
        gameObject.SetActive(false);
    }
}
