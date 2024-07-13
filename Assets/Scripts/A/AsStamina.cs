using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsStamina : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        while (true) {
            if (AsMove.stamina < 3f){
                yield return new WaitForSecondsRealtime(.3f);
                AsMove.stamina += .1f;
            }
            yield return new WaitForSecondsRealtime(.1f);
        }
    }
}
