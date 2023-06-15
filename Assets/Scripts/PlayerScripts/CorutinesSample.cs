using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorutinesSample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        for(int i = 0;i < 10; i++)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Corrutine " + i);
        }
    }
}
