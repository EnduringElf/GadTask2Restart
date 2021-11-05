using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    public GameObject theDestination;
    NavMeshAgent theAgent;
    private Animator npcAnimator;

    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        theAgent.SetDestination(theDestination.transform.position);
        if (theDestination.transform.position.x == gameObject.transform.position.x && theDestination.transform.position.z == gameObject.transform.position.z )
        {
            npcAnimator.SetBool("IsMoving", false);
        }
        else
        {
            npcAnimator.SetBool("IsMoving", true);
        }
    }
}

