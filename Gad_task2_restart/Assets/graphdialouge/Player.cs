using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]public Object[] Objects = new Object[10];
    private int i = 0;
    public void AddObject(string name)
    {
        foreach(Object _obj in Objects)
        {
            if(_obj.Name != name)
            {
                Debug.Log("item add to player inv: " + name);
                Objects[i] = new Object(name);
                i++;
            }
            
            
        }
    }


}
