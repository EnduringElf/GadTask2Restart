using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{

    public bool isGrounded;
    private void Awake()
    {
        isGrounded = true;
    }

    
    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }


   




}


