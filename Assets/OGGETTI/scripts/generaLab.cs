using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;

public class generaLab: MonoBehaviour
{
    [SerializeField]
    private casella cell;

    /*creazione labirinto*/
    [SerializeField]
    private int l; //lato del labirinto, tutti quadrati
    private casella[,] griglia; //array per tenere le caselle

    private void Start()
    {
        griglia = new casella[l, l];

        /*crea la base per il labirinto riempendo di caselle*/
        for (int x = 0; x < l; x++) 
        {
            for (int y = 0; y < l; y++)
            { 
                griglia[x, y] = Instantiate(cell, new Vector3(x*4, y*4, 0), Quaternion.identity);
            }
        }


    }

    private void genera(casella prec, casella att) 
    {
        att.Visita();
        eliminaMuro(prec, att);
    }

    private casella prossimaDaVisitare(casella att)
    {
        var i = Random.Range(0, 4);
        List<casella> l = new List<casella>();

        return l[i];
    }
    
    //elimina i muri che confinano per liberare la strada
    private void eliminaMuro(casella prec, casella att) 
    {
        if(prec == null) //la casella attuale è la prima, non rimuovo muri
            return;
        if(prec.transform.position.x < att.transform.position.x) //ci siamo mossi verso destra
        {
            prec.eliminaRight();
            att.eliminaLeft(); return;
        }
        if(prec.transform.position.x > att.transform.position.x) //ci siamo mossi verso sinistra
        {
            prec.eliminaLeft();
            att.eliminaRight(); return;
        }
        if(prec.transform.position.y < att.transform.position.y) //ci siamo mossi verso l'alto
        {
            prec.eliminaUp();
            att.eliminaDown(); return;
        }
        if(prec.transform.position.y > att.transform.position.y) //ci siamo mossi verso il basso
        {
            prec.eliminaDown();
            att.eliminaUp(); return;
        }
    }
}
