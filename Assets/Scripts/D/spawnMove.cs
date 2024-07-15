using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0.6f, 0.05f, 0f);
    }
}
