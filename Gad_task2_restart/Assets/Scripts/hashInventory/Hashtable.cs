using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hashtable<T> : MonoBehaviour
{
    public int size { get; set; }
    public Hashitem<T>[] inventory { get; set; }
    int totalitmes { get; set; }

    public Hashtable(int Size)
    {
        //if(Size > 0)
        {
            //Debug.Log("inizilise size:" + Size);
            //size = GetNextPrimeNumber(Size);
            size = Size;
            inventory = new Hashitem<T>[size];
            //Debug.Log("inventory at postion 0 is" + inventory[0]);
            //Debug.Log("inizilised final");
        }
    }
    

    ~Hashtable()
    {
        if(inventory != null)
        {
            inventory = null;

        }
    }

    private bool isNumPrime(int val)
    {
        for(int i = 2;(i * i) <= val; i++)
        {
            if ((val % i) == 0)
                return false;
        }
        
        return true;
    }

    private int GetNextPrimeNumber(int val)
    {
        
        for(int i = val+1; ; i++)
        {
            if (isNumPrime(i))
            {
                //Debug.Log("inizilise prime numer:" + i);
                return i;
                
            }

        }
        

    }

    public bool Insert(int key, T Obj)
    {
        
        if(totalitmes == size)
        {
            Debug.Log("cannot insert excedes limit total items [" +totalitmes+"] size ["+size+"]" );
            return false;
        }

        int hash = HashFunction(key);
        //Debug.Log("before while in insert: " + hash);
        //Debug.Log("int key: " + key);
        //Debug.Log(inventory);
        //Debug.Log("inventory +key: " + inventory[hash]);
                 
        //Debug.Log(inventory[hash]);
        if(inventory[hash] == null)
        {
            inventory[hash] = new Hashitem<T>();
            Debug.Log("inventory at " + hash + " is null");
        }
        while (inventory[hash].key != -1)
        {
            hash++;
            hash %= size;
        }

        Debug.Log("hash form insert:" + hash);

        inventory[hash].key = key;
        inventory[hash].Object = Obj;

        totalitmes++;
        Debug.Log("added object");
        return true;
    }

    private int HashFunction(int key)
    {
        return key % size;
    }

    public int HashFunction(string key)
    {
        int hash = 0;

        for(int i = 0; i<(int)key.Length ; i++)
        {
            int val = (int)key[i];
            hash = (hash + 256 + val) % size;
        }

        return hash;
    }

    public void delete(string key)
    {
        int hash = key.GetHashCode();
        int ogHash = hash;

        while(inventory[hash].key != -1)
        {
            inventory[hash].key = -1;
            totalitmes--;

            return;
        }

        hash++;
        hash %= size;

        if(ogHash == hash)
        return;
        


    }

    public bool find(int key, T obj)
    {
        int hash = HashFunction(key);

        int oghash = hash;

        while (inventory[hash].key != -1)
        {
            if(inventory[hash].key == key)
            {
                if(obj != null)
                {
                    obj = inventory[hash].Object;

                    return true;
                }
            }

            hash++;
            hash %= size;

            if (oghash == hash)

                return false;
        }

        return false;
    }

    



}
