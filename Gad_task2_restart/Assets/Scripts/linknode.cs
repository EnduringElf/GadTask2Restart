using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class linknode 
{
    
    public linknode Next;
    public linknode prev;
    public string Author { get; set; }
    public string Diag;
    public int Index;
    public int NextIndex;
    public string Item;
    public string ItemDiag;
    private linknode Linknode;

    public linknode()
    {
        Next = null;
        prev = null;
    }
    public linknode(linknode linknode)
    {
        this.Linknode = linknode;
    }
}

