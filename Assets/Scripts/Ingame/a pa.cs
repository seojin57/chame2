using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class apa : MonoBehaviour
{
    public float MaxHp;
    public float hp;
    public GameObject bar;
    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 100;
        hp = MaxHp;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("10"))
        {
            Destroy(other.gameObject);
            hp -= 10;
        }
        if(other.CompareTag("44"))
        {
            Destroy(other.gameObject);
            hp -= 44;
        }
    }

    void Update()
    {
        bar.GetComponent<Image>().fillAmount = hp/MaxHp;
        if (hp <= 0){
            SceneManager.LoadScene("title");
        }
    }
}
