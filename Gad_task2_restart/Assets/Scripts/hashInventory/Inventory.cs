using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Hashtable<GameObject> inventory;
    public GameObject testObj;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Hashtable<GameObject>(20);
        int objname = inventory.HashFunction(testObj.name);
        inventory.Insert(objname,testObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            //inventory.Insert(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
