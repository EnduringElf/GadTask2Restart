using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
    [System.Serializable]
public class game_manager : MonoBehaviour
{

    
    public TextAsset jsonfile;
    public Linkedlist dialogue;
    linknode[] test;
    public GameObject[] npcs;

    public string currentauthor;
    public string currenttext;

    //public TMP_Text author;
    //public TMP_Text diag;

    private void Update()
    {
        //author.text = currentauthor;
        //diag.text = currenttext;
    }

    private void Awake()
    {
        
        dialogue = new Linkedlist();
        test = JsonHelper.getJsonArray<linknode>(jsonfile.text);
        for(int i = 0; i < test.Length; i++)
        {
            dialogue.addnodeFront(dialogue, test[i]);
            //Debug.Log("from array next index " + i + ": " + test[i].NextIndex);
            Debug.Log("dialogue node :" + dialogue.Head.Diag);
        }
        
        //Debug.Log("game object arry size:" + npcs.Length);
        for (int i = 0; i > npcs.Length; i++)
        {
            //npcs[i].GetComponent<LoadDialogue>().loadallAuthorDialogue(npcs[i].GetComponent<LoadDialogue>().NPCdialogue);
        }

        Debug.Log("dialogue head file is: " + dialogue.Head.Diag);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadDialoguebyname(string author)
    {
        while(dialogue.Head.Author != author)
        {
            dialogue.Head = dialogue.Head.Next;
        }

    }

    
    


}
