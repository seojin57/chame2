using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public Text text;
    public int asPick;
    public int bsPick;
    void Start()
    {
        text.text = null;
    }

    public void P1a()
    {
        asPick = 1;
    }

    public void P1b()
    {
        asPick = 2;
    }

    public void P1c()
    {
        asPick = 3;
    }

    public void P1d()
    {
        asPick = 4;
    }

    public void P2a()
    {
        bsPick = 1;
    }

    public void P2b()
    {
        bsPick = 2;
    }

    public void P2c()
    {
        bsPick = 3;
    }

    public void P2d()
    {
        bsPick = 4;
    }

    public void GetStart()
    {
        if (asPick == 0 | bsPick == 0)
        {
            text.text = "양쪽 플레이어의 캐릭터를 모두 선택해주세요!";
        }
        else if (asPick == bsPick)
        {
            text.text = "캐릭터 선택은 겹칠 수 없습니다!";
        }
        else
        {
            if (asPick == 1 && bsPick == 2)
            {
                SceneManager.LoadScene("main1");
            }
            if (asPick == 1 && bsPick == 3)
            {
                SceneManager.LoadScene("main2");
            }
            if (asPick == 1 && bsPick == 4)
            {
                SceneManager.LoadScene("main3");
            }
            if (asPick == 2 && bsPick == 1)
            {
                SceneManager.LoadScene("main4");
            }
            if (asPick == 2 && bsPick == 3)
            {
                SceneManager.LoadScene("main5");
            }
            if (asPick == 2 && bsPick == 4)
            {
                SceneManager.LoadScene("main6");
            }
            if (asPick == 3 && bsPick == 1)
            {
                SceneManager.LoadScene("main7");
            }
            if (asPick == 3 && bsPick == 2)
            {
                SceneManager.LoadScene("main8");
            }
            if (asPick == 3 && bsPick == 4)
            {
                SceneManager.LoadScene("main9");
            }
            if (asPick == 4 && bsPick == 1)
            {
                SceneManager.LoadScene("main10");
            }
            if (asPick == 4 && bsPick == 2)
            {
                SceneManager.LoadScene("main11");
            }
            if (asPick == 4 && bsPick == 3)
            {
                SceneManager.LoadScene("main12");
            }
        }
    }
}
