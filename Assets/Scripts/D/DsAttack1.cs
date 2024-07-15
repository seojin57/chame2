using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DsAttack1 : MonoBehaviour
{
    public static float Bullets = 5;
    public Transform bulletSpawn;
    public Transform Gun;
    public GameObject bulletPrf;
    public GameObject bulletPrf1;
    public GameObject bulletPrf2;
    public GameObject Bbar;
    public float nextfire;
    public float fireRate = 0.1f;
    public float Reload = 2.5f;
    public bool OnReload = false;
    public bool Ulting = false;
    public bool onUlt = true;
    public static bool IsIdle;

    void Start()
    {
        Bbar.GetComponent<Image>().color = new Color32(51, 141, 51, 255);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump2") && DsMove.stunned == false && Bullets < 5 && !OnReload && !Ulting)
        {
            OnReload = true;
            StartCoroutine("Reroading");
        }

        if (Input.GetButtonDown("Fire22") && DsMove.stunned == false && !Ulting && !OnReload && onUlt)
        {
            onUlt = false;
            Ulting = true;
            Bullets = 5;
            Bbar.GetComponent<Image>().color = new Color32(0, 12, 255, 255);
            Invoke("UltCool", 50f);
        }

        if (Input.GetButtonDown("Fire12") && DsMove.stunned == false && Time.time > nextfire && !Ulting && Bullets >= 1 && !OnReload)
        {
            if (Bullets != 2)
            {
                IsIdle = DsMove.idle;
                nextfire = Time.time + fireRate;
                Bullets -= 1;
                Fire();
            }
            else if (Bullets == 2)
            {
                IsIdle = DsMove.idle;
                nextfire = Time.time + fireRate;
                Bullets -= 1;
                FuckingFire();
            }
        }

        if (Input.GetButtonDown("Fire12") && DsMove.stunned == false && Time.time > nextfire && Ulting && Bullets >= 1 && !OnReload)
        {
            IsIdle = DsMove.idle;
            nextfire = Time.time + fireRate;
            Bullets -= 1;
            UltFire();
        }

        if (Bullets == 0 && !onUlt && Ulting)
        {
            Ulting = false;
            Bbar.GetComponent<Image>().color = new Color32(51, 141, 51, 255);
        }

        if (Bullets > 5)
        {
            StopCoroutine("Reroading");
            Bullets = 5;
            OnReload = false;
        }

        Bbar.GetComponent<Image>().fillAmount = Bullets / 5;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrf, bulletSpawn.position, Gun.rotation);
        Destroy(bullet, 1.4f);
    }

    void FuckingFire()
    {
        GameObject bullet = Instantiate(bulletPrf1, bulletSpawn.position, Gun.rotation);
        Destroy(bullet, 2f);
    }

    void UltFire()
    {
        GameObject bullet = Instantiate(bulletPrf2, bulletSpawn.position, Gun.rotation);
        Destroy(bullet, 3f);
    }

    IEnumerator Reroading()
    {
        yield return null;
        while(true)
        {
            Bullets += 0.1f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
