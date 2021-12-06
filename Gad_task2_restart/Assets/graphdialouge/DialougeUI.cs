using TMPro;
using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class DialougeUI : MonoBehaviour
{
    [SerializeField] private GameObject DialougeBox;
    [SerializeField] private TMP_Text textlabel;
    [SerializeField] public DialougeObject testdiag;
    [SerializeField] private TMP_Text Speaker;
    [SerializeField] private TMP_Text npcnearbyText;
    [SerializeField] private TMP_Text ItemsNearbyText;
    [SerializeField] private TMP_Text Availblenames;
    [SerializeField] public GameObject Player;

    private Player player;
    

    private ResponseHandler responseHandler;
    private TypeWriterEffect TypeWriterEffect;
    private static DialougeUI instance;

    public string[] npcnearby;
    private string npcnearbytext;

    public string[] itemsnearby;
    private string _itemsnearby;
    public static DialougeUI getInstance()
    {
        if (instance == null)
        {
            return new DialougeUI();
        }
        return instance;
    }

    private void Start()
    {
        Speaker.text = "";
        textlabel.text = "";
        TypeWriterEffect = GetComponent<TypeWriterEffect>();
        CloseDialougeBox();
        responseHandler = GetComponent<ResponseHandler>();
        
        player = Player.GetComponent<Player>();

        //showDialouge(testdiag);

       
    }

    public void showDialouge(DialougeObject dialougeObject)
    {
        DialougeBox.SetActive(true);
        StartCoroutine(stepThroughDialouge(dialougeObject));
    }

    public void showDialouge()
    {
        DialougeBox.SetActive(true);
        StartCoroutine(stepThroughDialouge(testdiag));
    }

    private IEnumerator stepThroughDialouge(DialougeObject dialougeObject)
    {

        
        for(int i =  0; i < dialougeObject.dialouge.Length; i++)
        {
            Speaker.text = dialougeObject.speakers[i];
            string dialouge = dialougeObject.dialouge[i];
            yield return TypeWriterEffect.run(dialouge, textlabel);

            if (i == dialougeObject.dialouge.Length - 1 && dialougeObject.HasObjects) break;

            if (i == dialougeObject.dialouge.Length - 1 && dialougeObject.Hasresponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        }

        if (dialougeObject.Hasresponses)
        {
            responseHandler.showResponses(dialougeObject.Responses);
            
            

        }else if(dialougeObject.HasObjects)
        {
            List<ObjectDiag> objectDiags = new List<ObjectDiag>();
            for(int i = 0; i <  player.Objects.Length; i++)
            {
                //Debug.LogError("list objectdiags: " + player.Objects[i].Name);
                //Debug.LogError("list objectdiags: " + dialougeObject.objectDiags[i].Objname);


                if (player.Objects[i].Name == dialougeObject.objectDiags[i].Objname)
                {
                    objectDiags.Add(dialougeObject.objectDiags[i]);
                    //Debug.LogError("list objectdiags item: " + dialougeObject.objectDiags[i]);

                }
            }
            responseHandler.ShowObjects(objectDiags);
            
        }
        else
        {
            CloseDialougeBox();
        }
        yield return null;
    }

    private void CloseDialougeBox()
    {
        DialougeBox.SetActive(false);
        textlabel.text = "";
    }
}
