using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hashitem<Tvalue> : MonoBehaviour
{
    //Tkey key;
    //Tvalue value;

    public Hashitem()
    {
        key = 0;
    }

    ~Hashitem()
    {

    }
    public int key { get; set; }

    public Tvalue Object { get; set; }

    
   public bool isequal(Hashitem<Tvalue> item)
   {
        if(key == item.key)
        {
            return true;
        }
        else { return false; }
   }

    public void set(Hashitem<Tvalue> item)
    {
        key = item.key;
        Object = item.Object;
    }
    

}
