using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI testo;
    float tempo;
    int secondi;
    int minuti;

    void Update()
    {
        
        tempo += Time.deltaTime;
        secondi = Mathf.FloorToInt(tempo % 60);
        minuti = Mathf.FloorToInt(tempo / 60);
        testo.text = string.Format("{0:00}:{1:00}", minuti, secondi);

    }

}