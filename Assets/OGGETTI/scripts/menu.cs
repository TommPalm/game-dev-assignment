using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   public void PlayEasy()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayMedium()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void PlayHard()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void PlayReal()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
