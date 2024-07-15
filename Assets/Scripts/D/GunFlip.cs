using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlip : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float tx;
    public float ty;
    public float tz;
    void Start()
    {
        x = this.transform.localScale.x;
        y = this.transform.localScale.y;
        z = this.transform.localScale.z;

        tx = this.transform.localPosition.x;
        ty = this.transform.localPosition.y;
        tz = this.transform.localPosition.z;
    }

    void Update()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            this.transform.localScale = new Vector3(x, -y, z);
        }
        else
        {
            this.transform.localScale = new Vector3(x, y, z);
        }

        this.transform.localPosition = new Vector3(tx, ty, tz);
    }
}
