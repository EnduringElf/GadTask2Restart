using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diagManager : MonoBehaviour
{

    public GameObject game_Manager;
    public Textaction Textaction;
    public GameObject colliderobject;

    public GameObject dialougeUi;
    private void Start()
    {
        Textaction = game_Manager.GetComponent<Textaction>();
        dialougeUi = GameObject.Find("GraphCanvas");

    }

    public void maketextactionscript(Textaction textaction)
    {
        Textaction = textaction;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "npc")
        {
            dialougeUi.GetComponent<DialougeUI>().npcnearbyBox.SetActive(true);
            colliderobject = collision.gameObject;
            Textaction = game_Manager.GetComponent<Textaction>();
            Textaction.NPC_inrange = true;
            Debug.Log("npc in range " + Textaction.NPC_inrange);
            //Debug.Log("talking to " + dialougeUi.GetComponent<DialougeUI>() + " test diag:" );
           
            dialougeUi.GetComponent<DialougeUI>().npcnearbyText.text = colliderobject.gameObject.name;
            
        }
        if( collision.gameObject.tag == "item")
        {
            dialougeUi.GetComponent<DialougeUI>().itemsnearbybox.SetActive(true);
            Textaction = game_Manager.GetComponent<Textaction>();
            Textaction.Item_inrange = true;
            colliderobject = collision.gameObject;
            Debug.Log("item in range " + Textaction.NPC_inrange);
            

            dialougeUi.GetComponent<DialougeUI>().ItemsNearbyText.text = colliderobject.gameObject.name;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            Textaction = game_Manager.GetComponent<Textaction>();
            Textaction.NPC_inrange = false;
            colliderobject = null;
            Textaction.NPC_inrange = false;
            dialougeUi.GetComponent<DialougeUI>().npcnearbyBox.SetActive(false);

            dialougeUi.GetComponent<DialougeUI>().npcnearbyText.text = "awaiting...";

        }
        else if (collision.gameObject.tag == "item")
        {
            Textaction = game_Manager.GetComponent<Textaction>();
            Textaction.Item_inrange = false;
            colliderobject = null;
            Textaction.Item_inrange = false;
            dialougeUi.GetComponent<DialougeUI>().itemsnearbybox.SetActive(false);
            dialougeUi.GetComponent<DialougeUI>().ItemsNearbyText.text = "awaiting...";

        }
    }


}
