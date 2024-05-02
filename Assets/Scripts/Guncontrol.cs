using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guncontrol : MonoBehaviour
{
    public GameObject bullet;
    public Transform spoint;
    public float timeBetweenShots;

    private float shotTime;

    void Update()
    {
        //마우스 위치 바라보기
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        //총알발사
        if (Input.GetMouseButton(0))
        {
            if(Time.time >= shotTime)
            {
                Instantiate(bullet, spoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
