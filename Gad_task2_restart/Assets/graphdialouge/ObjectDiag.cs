using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ObjectDiag
{

    [SerializeField] private string m_ObjectText;
    [SerializeField] private DialougeObject DialougeObject;
    [SerializeField] private Object m_object;

    public string Object_Text => m_ObjectText;
    public object Object => m_object;
    public DialougeObject Dialouge => DialougeObject;
    public string Objname => m_object.Name;

}
