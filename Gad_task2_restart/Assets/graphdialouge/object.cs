using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Object 
{
    [SerializeField] string m_name;
    public string Name => m_name;
    public Object(string name)
    {
        m_name = name;
    }
}
