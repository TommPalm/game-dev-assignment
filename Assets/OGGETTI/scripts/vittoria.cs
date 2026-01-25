using UnityEngine;
using UnityEngine.SceneManagement;

public class vittoria : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        win();
    }


    [ContextMenu("win")]
    public void win()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
