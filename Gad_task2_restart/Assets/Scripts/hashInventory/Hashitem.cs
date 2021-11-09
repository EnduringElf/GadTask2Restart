using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hashitem<Tvalue> : MonoBehaviour
{
    //Tkey key;
    //Tvalue value;

    Hashitem()
    {
        key = 0;
    }
    ~Hashitem()
    {

    }
    public int key { get; set; }

    public Tvalue Object { get; set; }

    
   bool isequal(Hashitem<Tvalue> item)
    {
        if(key == item.key)
        {
            return true;
        }
        else { return false; }
   }

    void set(Hashitem<Tvalue> item)
    {
        key = item.key;
        Object = item.Object;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
