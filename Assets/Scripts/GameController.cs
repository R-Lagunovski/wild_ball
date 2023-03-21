using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject prevScreen;

    private GameObject curScreen;
    private bool paused;

    void Start()
    {
        prevScreen.SetActive(true);
        curScreen = prevScreen;
        Time.timeScale = 1;
        Debug.Log("Start " + paused + ' ' + Time.timeScale);

    }

    public void UpdateScreen(GameObject state)
    {
        if (curScreen != null)
        {
            curScreen.SetActive(false);
            state.SetActive(true);
            curScreen = state;
        }
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void PauseGame()
    {
        if (paused)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

        paused = !paused;
    }
}
