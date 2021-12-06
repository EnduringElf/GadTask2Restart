using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialougeObject DialougeObject;

    public string ResponseText => responseText;
    public DialougeObject Dialouge => DialougeObject;

}
