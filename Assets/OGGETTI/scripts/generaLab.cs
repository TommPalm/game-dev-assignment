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
    [SerializeField]
    private GameObject personaggio;
    [SerializeField]
    private GameObject sfondo;

    private int id=0;

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
        Instantiate(personaggio, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(sfondo, new Vector3(0, 0, 0), Quaternion.identity);
        scopri(griglia[0,0]);

    }
    /*genera ricorsivamente il labirinto "scoprendo" le caselle*/
    private void scopri(casella att)
    {
        att.id = this.id;
        this.id++;
        att.Visita();
        List<casella> list = getAdiacenti(att);
        list = list.OrderBy(_ => Random.value).ToList();
        /*estrae una delle adiacenti non visitate, elimina il muro e la visita*/
        for(int i=0; i<list.Count;i++)
        {
            if (list[i].isVisitato() == false)
            {
                eliminaMuro(att, list.ElementAt(i)  );
                scopri(list.ElementAt(i)  );
            }
        }

    }


    public List<casella> getAdiacenti(casella att)
    {
        List<casella> list = new List<casella>();
        /*prende le coordinate della casella*/
        int x =(int) att.transform.position.x;
        int y = (int)att.transform.position.y;

        /*aggiunge alla lista le caselle confinanti*/
        if (x -1 >= 0) //esiste una casella a sinistra non visitata
        {
            //if (griglia[x-1,y].isVisitato() == false) 
                list.Add(griglia[x - 1, y]);
        }
        if(x +1 < l) //esiste casella a destra non visitata
        {
           // if (griglia[x + 1, y].isVisitato() == false) 
                list.Add(griglia[x + 1, y]);
        }
        if(y-1>= 0)//esiste una casella sotto non visitata
        {
           // if (griglia[x, y - 1].isVisitato() == false) 
                list.Add(griglia[x, y - 1]);
        }
        if(y+1 < l)//esiste una casella sopra non visitata
        {
            //if (griglia[x, y + 1].isVisitato() == false) 
                list.Add(griglia[x, y + 1]);
        }

        return list;
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
