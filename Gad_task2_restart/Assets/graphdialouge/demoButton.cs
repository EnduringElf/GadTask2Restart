using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoButton : MonoBehaviour
{
    public DialougeObject test;
    public DialougeObject complex;
    public DialougeObject Object;

    public GameObject Player;
    public GameObject UI;

    public Object @object;
    
    public void Onclicktest()
    {
        UI.GetComponent<DialougeUI>().showDialouge(test);
        
    }

    public void Onclickcomplex()
    {
        UI.GetComponent<DialougeUI>().showDialouge(complex);
    }

    public void Onclickobject()
    {
        UI.GetComponent<DialougeUI>().showDialouge(Object);
    }

    public void GivePlayerObject()
    {
        Player.GetComponent<Player>().Objects[0] = @object;
    }
    public void RemovePlayerObject()
    {
        Player.GetComponent<Player>().Objects[0] = null;
    }




}
