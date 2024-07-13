using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsStamina1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        while (true) {
            if (AsMove1.stamina < 3f){
                yield return new WaitForSecondsRealtime(.3f);
                AsMove1.stamina += .1f;
            }
            yield return new WaitForSecondsRealtime(.1f);
        }
    }
}
