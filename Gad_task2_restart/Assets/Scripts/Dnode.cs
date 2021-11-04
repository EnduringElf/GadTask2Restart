using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Dnode : MonoBehaviour
{
    public Dnode next;
    public Dnode prev;

    public string Author;
    public string Diag;
    public string Item;
    public string ItemDiag;

    private Dnode dnode;


    public Dnode(Dnode temp)
    {
        this.dnode = temp;
    }



}
