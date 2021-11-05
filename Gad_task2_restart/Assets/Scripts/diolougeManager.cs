using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
[System.Serializable]

public class diolougeManager : MonoBehaviour
{
    public string author;

    public TextAsset jsonfile;

    public  Dlinkedlist dialogue;

    public Dnode[] test;

    //public Dnode head;
    private void Awake()
    {

        dialogue = new Dlinkedlist();
        Debug.Log("json file:" + jsonfile.text);
        test = JsonHelper.getJsonArray<Dnode>(jsonfile.text);
        //Debug.Log("test postition 0 diag:" + test[0].Diag);
        for (int i = 0; i < test.Length; i++)
        {
            dialogue.AddnodeEnd(dialogue, test[i]);
            //Debug.Log("from array next index " + i + ": " + test[i].NextIndex);
            //Debug.Log("dialogue node author:" + dialogue.Head.Author);
        }

        //Debug.Log("get next at head: " + dialogue.getNext(dialogue));
        //Debug.Log("head diag is:" + dialogue.displayhead(dialogue));
        //head = dialogue.head;
        //Debug.Log("get prev at head: " + dialogue.getBefore(dialogue));
    }


}
