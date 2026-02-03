using UnityEngine;

public class gestore : MonoBehaviour
{
    [SerializeField]
    private GameObject pausa;
    [SerializeField]
    private GameObject play;
    void Start()
    {
        pausa.SetActive(false);
    }


    public void Pausa()
    {
        pausa.SetActive (true);
        Time.timeScale = 0f;
    }
    public void Play()
    {
        pausa.SetActive(false);
        Time.timeScale = 1f;
    }


}
