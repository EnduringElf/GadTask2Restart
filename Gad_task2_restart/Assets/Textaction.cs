using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textaction : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    public GameObject Destionobj;
    [SerializeField]public GameObject target;
    public GameObject dialougeUi;
    [SerializeField] DialougeObject testdiag;

    //private static Textaction instance;

    [SerializeField]public bool NPC_inrange;
    public bool Item_inrange;


    //public static Textaction getInstance()
    //{
    //    if(instance == null)
    //    {
    //        return new Textaction();
    //    }
    //    return instance;
    //}

    // Start is called before the first frame update
    void Start()
    {


        //Player.GetComponent<NpcMovement>().theDestination = Destionobj;
        dialougeUi = GameObject.Find("GraphCanvas");
        //Debug.Log("destion transform:" + Destination.position);

    }

    // Update is called once per frame
    void Update()
    {
        //Player.GetComponent<NpcMovement>().theDestination = target;
        //Debug.Log(testdiag);
        
    }

    public void walk(GameObject @object)
    {
        
        Debug.Log("walking to " + @object);
        Player = GameObject.Find("Player");
        //Debug.Log("player " + Player);
        Player.GetComponent<NpcMovement>().theDestination.transform.position = @object.transform.position;

    }


    public void Talk(GameObject @object)
    {
        Debug.Log("is npc in range: " + NPC_inrange);
        if(NPC_inrange == true)
        {
            dialougeUi = GameObject.Find("GraphCanvas");
            //Debug.Log("talking to " + dialougeUi.GetComponent<DialougeUI>() + " test diag:" );
            dialougeUi.GetComponent<DialougeUI>().showDialouge(Player.gameObject.GetComponentInChildren<diagManager>().colliderobject.GetComponent<diagholder>().dialouge);
        }
        else
        {
            Debug.Log("NPC not in range");
        }
        
    }

    public void Pick()
    {
        if (Item_inrange)
        {
            //getInstance();
            
        }
        else
        {
            Debug.Log("NPC not in range");
        }
    }

}
