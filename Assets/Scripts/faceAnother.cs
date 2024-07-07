using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceAnother : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        Vector2 newPos = target.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
