using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{


    public void Exit()
    {
        Application.Quit();
    }
    public void PlayEasy()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayMedium()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayHard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayReal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(4);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
}
