using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class diolougeManager : MonoBehaviour
{
    public string author;

    public TextAsset jsonfile;

    public  Dlinkedlist dialogue;

    Dnode[] test;

    private void Awake()
    {
        dialogue = new Dlinkedlist();
        test = JsonHelper.getJsonArray<Dnode>(jsonfile.text);
        for (int i = 0; i < test.Length; i++)
        {
            dialogue.AddnodeEnd(dialogue, test[i]);
            //Debug.Log("from array next index " + i + ": " + test[i].NextIndex);
            //Debug.Log("dialogue node :" + dialogue.Head.Diag);
        }


        //Debug.Log("dialogue at head  is: " + dialogue.head.Diag);
    }


}
