using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideLetters : MonoBehaviour
{
    public GameObject letter1, letter2, letter3;
    public void Start()
    {
        StartCoroutine(animate());
    }

    IEnumerator animate()
    {
        while (true)
        {

            letter1.SetActive(true);
            letter2.SetActive(false);
            letter3.SetActive(false);

            yield return new WaitForSeconds(1);

            letter1.SetActive(false);
            letter2.SetActive(true);
            letter3.SetActive(false);

            yield return new WaitForSeconds(1);

            letter1.SetActive(false);
            letter2.SetActive(false);
            letter3.SetActive(true);

            yield return new WaitForSeconds(1);
        }
    }
}
