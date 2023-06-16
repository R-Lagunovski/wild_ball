using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

public class CourutineScript : MonoBehaviour
{
    private GameController gameController;
    void Start()
    {
        
        GameController gameController = GetComponent<GameController>();
    }

    public void StartCoroutine()
    {
        Coroutine coroutine = StartCoroutine(endGameTimer());
    }

    private IEnumerator endGameTimer()
    {
        yield return new WaitForSeconds(2f);
        gameController.RestartMenu();
        Debug.Log("Coroutine.");
    }
}