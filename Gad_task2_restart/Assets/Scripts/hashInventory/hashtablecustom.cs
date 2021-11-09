using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hashtablecustom<T> : MonoBehaviour
{
    int size { get; set; }
    Hashitem<T>[] inventory;
    int totalitmes;

    public hashtablecustom()
    {
        if (size == 0)
        {
            size++;
            inventory = new Hashitem<T>[16000];
            
        }
    }
    public hashtablecustom(int Size)
    {
        size = Size;
        inventory = new Hashitem<T>[size];
    }

    public void Insert( T Obj)
    {
        if(totalitmes == size)
        {
            return;
        }

        int hash = Obj.GetHashCode();

        Debug.Log("hash: " + hash);

        inventory[hash].Object = Obj;

        
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
