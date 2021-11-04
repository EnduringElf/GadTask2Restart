using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dlinkedlist : MonoBehaviour
{
    public Dnode head;
    public Dnode currrent;

   

    public void AddnodeFirst(Dlinkedlist list, Dnode parse)
    {
        Dnode Next = parse;
        Next.next = list.head;
        Next.prev = null;
        if(list.head != null)
        {
            list.head.prev = Next;
        }
        //Debug.Log("created new node (diag : " + Next.dnode.Diag + " )");
        list.head = Next;
    }

    public void AddnodeEnd(Dlinkedlist list, Dnode parsenode)
    {
        
        Dnode Nextnode = parsenode;
        if(list.head == null)
        {
            Nextnode.prev = null;
            list.head = Nextnode;
            return;
        }
        Dnode lastnode = GetlastNode(list);
        lastnode.next = Nextnode;
        Nextnode.prev = lastnode;
    }

    private Dnode GetlastNode(Dlinkedlist list)
    {
        Dnode temp = list.head;
        while(temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }

    public Dnode FindByauthor(Dlinkedlist list, string author)
    {
        Dnode temp;
        temp = list.head;
        while(temp.Author != author)
        {
            temp = temp.next;
        }
        return temp;
    }

    public Dnode getNext(Dnode current)
    {
        Dnode temp = new Dnode(current);
        temp = temp.next;
        return temp;
    }

    public Dnode getBefore(Dnode current)
    {
        Dnode temp = new Dnode(current);
        temp = temp.prev;
        return temp;
    }
}
