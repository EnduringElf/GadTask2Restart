using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[System.Serializable]
public class loaddiag3 : MonoBehaviour
{
    public GameObject Manager;
    diolougeManager diolougeManager;
    public string author;
    string currenttext;
    string currentAuthor;
    bool hasplayer;
    Dlinkedlist speakerdiag;

    public TMP_Text Author;
    public TMP_Text Diolouge;

    public TMP_Text player;

    
    void Start()
    {
        Author.text = "";
        Diolouge.text = "";
        player.text = "";
        Manager = GameObject.Find("Game_manager");
        
    }
    void Update()
    {
        if(hasplayer == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                loadNext();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                loadBefore();
            }
        }
        
    }

    private void loadBefore()
    {
        if (speakerdiag.head.Author == this.author)
        {
            if (speakerdiag.head.prev.Author == this.author)
            {
                speakerdiag.head = speakerdiag.head.prev;
                Debug.Log("updating head node");
            }
            Diolouge.text = speakerdiag.head.Diag;
            if (speakerdiag.head.Player == "player")
            {
                player.text = "Player";
                Author.text = "";
            }
            else
            {
                player.text = "";
                Author.text = speakerdiag.head.Author;
            }
            //Debug.Log("next node in speakerdiag is: " + speakerdiag.head.next.Diag);
            

        }
    }

    private void loadNext()
    {
        if(speakerdiag.head.Author == this.author)
        {
            Diolouge.text = speakerdiag.head.Diag;
            if(speakerdiag.head.Player == "player")
            {
                player.text = "Player";
               Author.text = "";

            }
            else
            {
                player.text = "";
                Author.text = speakerdiag.head.Author;
            }
            //Debug.Log("next node in speakerdiag is: " + speakerdiag.head.next.Diag);
            if(speakerdiag.head.next.Author == this.author)
            {
                speakerdiag.head = speakerdiag.head.next;
                Debug.Log("updating head node");
            }
            
        }
    }

    private void Loaddiag3()
    {
        speakerdiag.head = diolougeManager.dialogue.head.next;
        while (speakerdiag.head.Author != author)
        {
            speakerdiag.head = speakerdiag.head.next;
        }
        Debug.Log(speakerdiag.head.next.Author);

    }

    private void OnTriggerEnter(Collider other)
    {
        diolougeManager = Manager.GetComponent<diolougeManager>();
        speakerdiag = new Dlinkedlist();

        Loaddiag3();


        hasplayer = true;
        if (other.gameObject.tag == "Player")
        {
            displaydiolouge();
            Debug.Log("found plyer");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasplayer = false;
        clearui();
    }

    private void clearui()
    {
        Author.text = "";
        player.text = "";
        Diolouge.text = "";
    }

    private void displaydiolouge()
    {
        Debug.Log("press x to interact");
        Author.text = this.author;
        Diolouge .text= "prss x to interact";

    }
}
