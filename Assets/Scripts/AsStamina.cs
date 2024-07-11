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
            if (AsMove.stamina <= 2f){
                yield return new WaitForSecondsRealtime(3.0f);
                AsMove.stamina += 1;
            }
            yield return new WaitForSecondsRealtime(.1f);
        }
    }
}
