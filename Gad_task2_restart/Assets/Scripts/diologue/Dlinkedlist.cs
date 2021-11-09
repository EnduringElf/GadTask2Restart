using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dlinkedlist : MonoBehaviour
{
    public Dnode head;
    public Dnode currrent;

    public Dlinkedlist()
    {
        head = new Dnode();
        currrent = head;
    }
    
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
        //Debug.Log("adding linknode diag " + parsenode.Diag);
        Dnode Nextnode = parsenode;
        //Debug.Log("new node now has the following diag: " + Nextnode.Diag);
        if (list.head == null)
        {
            Debug.Log("no head seen");
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
        Debug.Log("finding author");
        Dnode temp = list.currrent;
        
        while(temp.Author != author)
        {
            temp = temp.next;
        }
        Debug.Log("author found");
        //Debug.Log("node diag:" + temp.Diag);
        return temp;
    }

    public Dnode getNext(Dnode current)
    {
        Dnode temp = current;
        if (temp.next != null)
        {
            temp = temp.next;
            return temp;
        }
        else
        {
            Debug.LogError("getnext has return null");
            return temp;
        }
    }
    public Dnode getNext(Dlinkedlist list)
    {
        Dnode temp = list.head;
        return getNext(temp);
    }
    

    public Dnode getBefore(Dnode current)
    {
        Dnode temp = current;
        if (temp.prev != null)
        {
            temp = temp.prev;
            return temp;
        }
        else
        {
            Debug.LogError("getbefore has return null");
            return temp;
        }
    }
    public Dnode getBefore(Dlinkedlist list)
    {
        Dnode temp = list.head;
        return getBefore(temp);

    }
    public string displayhead(Dlinkedlist linkedlist)
    {
        return linkedlist.head.Diag;
    }
    public Dnode gethead(Dlinkedlist list)
    {
        return head;
    }
    public Dnode n_head(Dlinkedlist list)
    {
        return list.head.next;
    }
   
    public void DisplayLastNode(Dlinkedlist linkedlist)
    {
        Debug.Log("last node diag: " + GetlastNode(linkedlist).Diag);
    }
}
