using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class loaddiag2 : MonoBehaviour
{
    public GameObject Manager;
    diolougeManager diolougeManager;
    public string author;
    string currenttext;
    string currentAuthor;
    bool hasplayer;
    Dlinkedlist authordiag;

    public TMP_Text Author;
    public TMP_Text Diolouge;

    public TMP_Text player;

    int counter = 0;


    //Linkedlist npcdiag;
    private void Start()
    {

        Diolouge.text = currenttext;
        Author.text = currentAuthor;
        player.text = "";
        //npcdiag = new Linkedlist();
        Manager = GameObject.Find("Game_manager");
        diolougeManager = Manager.GetComponent<diolougeManager>();
        //Debug.Log("diologue manager head is :" + diolougeManager.dialogue.head.next.Diag);
        
        authordiag = diolougeManager.dialogue;
        Load_npc_diag(diolougeManager.dialogue, author);

    }

    public void Load_npc_diag(Dlinkedlist maindiag, string author)
    {
        //while (maindiag.head.Author != author && maindiag.head.next != null)
        //{
        //    //Debug.Log(authordiag.head.Diag);
        //    maindiag.head = authordiag.getNext(maindiag);
        //}
        //Debug.Log(authordiag.FindByauthor(authordiag, author).Diag);
        //authordiag.currrent = authordiag.FindByauthor(authordiag, author);
        authordiag.head = authordiag.FindByauthor(authordiag, author);
        //Debug.Log("current head next is:" + maindiag.head.next.Diag);
    }
    private void Update()
    {
        Diolouge.text = currenttext;
        Author.text = currentAuthor;
        if (Input.GetKeyDown(KeyCode.X))
        {
            loadnextdialogue(authordiag);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("keycode : Z");
            loadlastdialogue(authordiag);
        }
        if (hasplayer == false)
        {
            currentAuthor = "";
            currenttext = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasplayer = true;
        if (other.gameObject.tag == "Player")
        {
            diolougeManager.author = this.author;
            displayfirstdialogue(authordiag);
            Debug.Log("found plyer");
        }
    }

    private void displayfirstdialogue(Dlinkedlist maindiag)
    {
        if (maindiag.head.next.Author == author)
        {
            currentAuthor = authordiag.head.next.Author;
            currenttext = "press X to begin conversation";
            Debug.Log(authordiag.head.next.Diag);
        }
        else
        {

            loadlastdialogue(authordiag);
        }
    }

    private void loadnextdialogue(Dlinkedlist maindiag)
    {

        while (maindiag.head.Author != author && maindiag.head.next != null)
        {
            maindiag.head = maindiag.head.next;
        }

        if (maindiag.head.Author == author)
        {
            if (maindiag.head != null && maindiag.head.Author == author)
            {
                if (maindiag.head.Player == "player")
                {
                    player.text = "player";
                    currentAuthor = "";
                }
                else
                {
                    player.text = "";
                    currentAuthor = maindiag.head.Author;
                }

                currenttext = maindiag.head.Diag;
                Debug.Log(maindiag.head.Diag);
                maindiag.head = maindiag.getNext(maindiag);
                counter++;
                Debug.Log("counter: " + counter);
            }

        }
    }
    private void loadlastdialogue(Dlinkedlist maindiag)
    {

        while(maindiag.head.Author != author && maindiag.head.prev != null)
        {
            maindiag.head = maindiag.head.prev;
        }
        if (maindiag.head.Author == author)
        {
            Debug.Log(authordiag.head.Diag);
            if (maindiag.head != null && maindiag.head.Author == author)
            {
                if(maindiag.head.prev.Author == author)
                {
                    maindiag.head = maindiag.getBefore(maindiag);
                }
                
                currenttext = maindiag.head.Diag;

                if (authordiag.head.Player == "player")
                {
                    player.text = "player";
                    currentAuthor = "";
                }
                else
                {
                    player.text = "";
                    currentAuthor = maindiag.head.Author;
                }
                if(counter > 0)
                {
                    counter--;
                }
                
                Debug.Log("counter: " + counter);
                Debug.Log(authordiag.head);

            }
        }
    }
    //private void loadnextdialogue(Dlinkedlist maindiag)
    //{
    //    Dnode temp = maindiag.head;

    //    if (temp.Author != author && temp.next != null)
    //    {
    //        temp = temp.next;
    //    }

    //    if (temp.Author == author)
    //    {
    //        if (temp != null)
    //        {
    //            if (temp.Player == "player")
    //            {
    //                player.text = "player";
    //                currentAuthor = "";
    //            }
    //            else
    //            {
    //                player.text = "";
    //                currentAuthor = temp.Author;
    //            }

    //            currenttext = temp.Diag;
    //            Debug.Log(temp.Diag);
    //            temp = authordiag.getNext(maindiag);
    //            counter++;
    //            Debug.Log("counter: " + counter);
    //        }

    //    }
    //}
    //private void loadlastdialogue(Dlinkedlist maindiag)
    //{
    //    Dnode temp = maindiag.head;
    //    if (temp.Author != author && temp.prev != null)
    //    {
    //        temp = temp.prev;
    //    }
    //    if (temp.Author == author)
    //    {
    //        Debug.Log(temp.Diag);
    //        if (temp.prev != null)
    //        {
    //            if (temp.Player == "player")
    //            {
    //                player.text = "player";
    //                currentAuthor = "";
    //            }
    //            else
    //            {
    //                player.text = "";
    //                currentAuthor = temp.Author;
    //            }

    //            currenttext = temp.Diag;
    //            temp = maindiag.getBefore(maindiag);
    //            counter--;
    //            Debug.Log("counter: " + counter);
    //            Debug.Log(temp);

    //        }
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        hasplayer = false;
        player.text = "";
        for (int i = 0; i < counter; i++)
        {
            authordiag.head = authordiag.getBefore(authordiag);
            Debug.Log(authordiag.head.Diag);
        }
        counter = 0;


    }
    private void loadfromstart()
    {
        if (authordiag.head != authordiag.currrent)
        {
            authordiag.head = authordiag.currrent;
            authordiag.head = authordiag.FindByauthor(authordiag, author);
        }
    }

}
