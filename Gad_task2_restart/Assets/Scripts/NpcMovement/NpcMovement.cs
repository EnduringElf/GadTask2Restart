using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    public GameObject theDestination;
    public GameObject secondD;
    bool endreach = false;
    NavMeshAgent theAgent;
    private Animator npcAnimator;
    bool activewalk;

    

    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        theAgent = GetComponent<NavMeshAgent>();
        activewalk = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(activewalk == true)
        {
            if (!endreach)
            {
                theAgent.SetDestination(theDestination.transform.position);
                if (theDestination.transform.position.x == gameObject.transform.position.x && theDestination.transform.position.z == gameObject.transform.position.z)
                {
                    endreach = true;
                }
            }
            else
            {
                theAgent.SetDestination(secondD.transform.position);
                if (secondD.transform.position.x == gameObject.transform.position.x && secondD.transform.position.z == gameObject.transform.position.z)
                {
                    endreach = false;
                }
            }
        }
       

        
        
        //if (theDestination.transform.position.x == gameObject.transform.position.x && theDestination.transform.position.z == gameObject.transform.position.z )
        //{
        //    npcAnimator.SetBool("IsMoving", false);
        //}
        //else
        //{
        //    npcAnimator.SetBool("IsMoving", true);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        activewalk = false;
        Vector3 nexttoplayer = other.transform.position;
        nexttoplayer.x += 1.5f;
        theAgent.SetDestination(other.transform.position);
        if (other.gameObject.tag == "Player")
        {
            npcAnimator.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        activewalk = true;
        if (other.gameObject.tag == "Player")
        {
            npcAnimator.SetBool("IsMoving", true);
        }
    }

    


}

