using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject prevScreen;
    [SerializeField] private GameObject restartMenu;

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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartMenu()
    {
        Debug.Log("Restart Menu");
        PauseGame();

        if (curScreen != null)
        {
            curScreen.SetActive(false);
            restartMenu.SetActive(true);
            curScreen = restartMenu;
        }
    }

    public void StartRestartCoroutine()
    {
        Coroutine coroutine = StartCoroutine(endGameTimer());
    }

    private IEnumerator endGameTimer()
    {
        yield return new WaitForSeconds(2f);
        RestartMenu();
        Debug.Log("Coroutine.");
    }
}
