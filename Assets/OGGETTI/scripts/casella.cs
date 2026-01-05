using UnityEngine;

public class casella: MonoBehaviour
{
    [SerializeField]
    private GameObject mU; //muro up
    [SerializeField]
    private GameObject mD; //muro down
    [SerializeField]
    private GameObject mR; //muro right
    [SerializeField]
    private GameObject mL; //muro left
    [SerializeField]
    private GameObject NV; //copertura per caselle non visitate

    private bool isVisited=false;

    public void Visita()
    {
        isVisited = true;   
        NV.SetActive(false);
    }

    public void eliminaUp() //elimina la parete up
    {
        mU.SetActive(false);
    }
    public void eliminaDown() //elimina la parete down
    {
        mD.SetActive(false);
    }
    public void eliminaLeft() //elimina la parete left
    {
        mL.SetActive(false);
    }
    public void eliminaRight() //elimina la parete right
    {
        mR.SetActive(false);
    }
}
