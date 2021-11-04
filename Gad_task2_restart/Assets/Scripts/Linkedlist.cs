using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linkedlist : MonoBehaviour
{
    public linknode Head;
    public linknode current;
    public TextAsset jsonfile;
    //public linknode defualtprev;

    public Linkedlist()
    {
        Head = new linknode();
        current = Head;
        //defualtprev.Author = "empty null";
    }
    public void setHeadto1(Linkedlist linkedlist)
    {
        linkedlist.Head = linkedlist.Head.Next;
    }
    public void displayhead(Linkedlist linkedlist)
    {
        Debug.Log("current head diag is :" + linkedlist.Head.Diag);
    }
    public void DisplayLastNode(Linkedlist linkedlist)
    {
        Debug.Log("last node diag: " + GetLastNode(linkedlist).Diag);
    }
    public void addnodeFront(Linkedlist linkedlist, linknode parsenode)
    {

        linknode newNode = parsenode;
        newNode.Next = linkedlist.Head;
        newNode.prev = null;
        if (linkedlist.Head != null)
        {
            linkedlist.Head.prev = newNode;
        }
        linkedlist.Head = newNode;
        //Debug.Log("sucssuffully made node with index :" + newNode.Index);
    }

    public void Addnodelast(Linkedlist linkedlist, linknode linknode)
    {
        //Debug.Log("adding linknode diag " + linknode.Diag);
        linknode newNode = linknode;
        Debug.Log("new node now has the following diag: " + newNode.Diag);
        if (linkedlist.Head == null)
        {
            newNode.prev = null;
            //newNode.prev = defualtprev;
            linkedlist.Head = newNode;
            return;
        }
        linknode lastNode = GetLastNode(linkedlist);
        lastNode.Next = newNode;
        newNode.prev = lastNode;
        //Debug.Log("sucssuffully made node with index :" + newNode.Diag);
    }

    public linknode GetLastNode(Linkedlist linkedlist)
    {
        linknode temp = linkedlist.Head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        return temp;
    }
    private void empty()
    {
    //public linknode SearchByIndexforlinknode(Linkedlist linkedlist , int index)
    //{
    //    linknode temphead = linkedlist.Head;
    //    //string temp;
    //    while(temphead.Index != index)
    //    {
    //        temphead = temphead.Next;
    //    }
    //    return temphead;
    //}

    //public string searchfornextindex(Linkedlist linkedlist, int nextindex)
    //{
    //    linknode temp = linkedlist.Head;
    //    while(temp.Index != nextindex)
    //    {
    //        temp = temp.Next;
    //    }
    //    return temp.Diag;
    //}

    //linknode SearchByAuthor(Linkedlist linkedlist,string author)
    //{
    //    linknode temphead = linkedlist.Head;
    //    //string temp;
    //    while (temphead.Author != author)
    //    {
    //        temphead = temphead.Next;
    //    }
    //    return temphead;
    //}

    //public string searchbyauthorfirstforfirstdiag(Linkedlist linkedlist, string author)
    //{

    //    linknode temphead = linkedlist.Head;
    //    if(temphead.prev == null)
    //    {
    //        while (temphead.Author != author)
    //        {
    //            if (temphead == null)
    //            {
    //                break;
    //            }
    //            temphead = temphead.Next;
    //        }
    //        return temphead.Diag;
    //    }
    //    else
    //    {
    //        Debug.LogError("prev exist ");
    //        return "broken";
    //    }
       
    //}
    }
    

    public linknode getNext(Linkedlist list)
    {
        linknode temp = list.Head;
        temp = temp.Next;
        return temp;
    }

}


