using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform ResponseContainer;

    private DialougeUI DialougeUI;

    List<GameObject> tempresponsebutton = new List<GameObject>();

    private void Start()
    {
        responseBox.gameObject.SetActive(false);
        DialougeUI = GetComponent<DialougeUI>();

    }

    public void showResponses(Response[] responses)
    {
        
        float responseboxhieght = 0;

        foreach(Response response in responses)
        {
            
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, ResponseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(call: () => OnPickResponse(response));

            tempresponsebutton.Add(responseButton);

            responseboxhieght += responseButtonTemplate.sizeDelta.y;
        }
        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, y: responseboxhieght);
        responseBox.gameObject.SetActive(true);
    }

    public void ShowObjects(List<ObjectDiag> objectDiags)
    {
        float responseBoxHieght = 0;
        //Debug.LogError("list objectdiags: " + objectDiags.Count);

        foreach (ObjectDiag objectDiag in objectDiags)
        {

            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, ResponseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = objectDiag.Object_Text;
            responseButton.GetComponent<Button>().onClick.AddListener(call: () => OnPickResponse(objectDiag));

            tempresponsebutton.Add(responseButton);

            responseBoxHieght += responseButtonTemplate.sizeDelta.y;

        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, y: responseBoxHieght);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);
        foreach(GameObject button in tempresponsebutton)
        {
            Destroy(button);
        }
        tempresponsebutton.Clear();
        DialougeUI.showDialouge(response.Dialouge);
    }
    private void OnPickResponse(ObjectDiag objectDiag)
    {
        responseBox.gameObject.SetActive(false);
        foreach (GameObject button in tempresponsebutton)
        {
            Destroy(button);
        }
        tempresponsebutton.Clear();
        DialougeUI.showDialouge(objectDiag.Dialouge);
    }
}
