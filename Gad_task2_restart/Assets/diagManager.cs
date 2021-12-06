using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diagManager : MonoBehaviour
{

    public GameObject game_Manager;
    public Textaction Textaction;
    public GameObject colliderobject;
    private void Start()
    {
        Textaction = game_Manager.GetComponent<Textaction>();
    }

    public void maketextactionscript(Textaction textaction)
    {
        Textaction = textaction;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "npc")
        {
            colliderobject = collision.gameObject;
            Textaction = game_Manager.GetComponent<Textaction>();
            Textaction.NPC_inrange = true;
            Debug.Log("npc in range " + Textaction.NPC_inrange);
            
        }
        else if( collision.gameObject.tag == "item")
        {
            colliderobject = collision.gameObject;
            Textaction.Item_inrange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            colliderobject = null;
            Textaction.NPC_inrange = false;
        }
        else if (collision.gameObject.tag == "item")
        {
            colliderobject = null;
            Textaction.Item_inrange = false;
        }
    }


}
