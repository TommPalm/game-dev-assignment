using NUnit.Framework;
using System.Collections;
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

    void Start()
    {
        griglia = new casella[l, l];

        /*crea la base per il labirinto riempendo di caselle*/
        for (int x = 0; x < l; x++) 
        {
            for (int y = 0; y < l; y++)
            { 
                griglia[x, y] = Instantiate(cell, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        genera(null, griglia[0,0]);

    }
    /*genera ricorsivamente il labirinto "scoprendo" le caselle*/
    private void genera(casella prec, casella att) 
    {
        att.Visita();
        eliminaMuro(prec, att);
        casella pros;

         //evita che si blocchi prima di aver visitato tutte le celle non visitate:
        do  //in caso una cella non abbia confinanti non visitati torna alla cella precedente
        {
            pros = prossimaDaVisitare(att);

            if (pros != null)
            {
                genera(att, pros);
            }
        } while (pros != null);
    }

    private casella prossimaDaVisitare(casella att)
    {
        
        List<casella> list = new List<casella>();


        /*inseriamo le caselle confinanti non visitate*/
        int x = (int) att.transform.position.x;
        int y = (int) att.transform.position.y;
        //esiste la casella a destra
        if(x+1<l)
        {
            if(griglia[x+1,y].isVisitato()==false) list.Add(griglia[x + 1, y]);
        }
        //esiste la casella a sinistra
        if (x - 1 >=0)
        {
            if(griglia[x - 1, y].isVisitato() == false) list.Add(griglia[x - 1, y]);
        }
        //esiste la casella sopra
        if (y +1 < l)
        {
            if(griglia[x , 1+ y].isVisitato() == false) list.Add(griglia[x ,1+ y]);
        }
        //esiste la casella a destra
        if (y - 1 >=0 && griglia[x,y-1].isVisitato() == false)
        {
            list.Add(griglia[x, y - 1]);
        }
        
        int i = Random.Range(0, list.Count);//estrae a caso una delle caselle
        return list[i];
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
