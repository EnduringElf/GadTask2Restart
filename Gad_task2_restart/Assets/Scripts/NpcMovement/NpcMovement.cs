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
    public bool Playercontrol = false;
    public bool randomPathing;
    public bool defualtpathign2;
    public bool ismoving;

    public GameObject[] destionations;

    public GameObject currentdestion;
    public GameObject model;
    
    // Start is called before the first frame update
    void Start()
    {
        if (randomPathing)
        {
                    destionations = GameObject.FindGameObjectsWithTag("destionations");

        }
        
        theAgent = GetComponent<NavMeshAgent>();
        activewalk = true;
        
    }
    
    // Update is called once per frame
    void Update()
    {

        //ismoving = npcAnimator.GetBool("IsMoving");
        if(Playercontrol == true)
        {
            npcAnimator = model.GetComponent<Animator>();
                //Debug.Log("destionation postion:" + theDestination.transform.position);
                theAgent.SetDestination(theDestination.transform.position);
                theAgent.speed = 10;
            if (theAgent.remainingDistance != 0 )
            {
                npcAnimator.SetBool("IsMoving", true);
            }
            else
            {
                npcAnimator.SetBool("IsMoving", false);
            }
            
           

        }
        else if (randomPathing)
        {
            npcAnimator = GetComponent<Animator>();
            Wait(4);
            randomPathing = false;
        }else if(defualtpathign2)
        {
            npcAnimator = GetComponent<Animator>();
            if (activewalk == true)
            {
                if (!endreach)
                {
                    theAgent.SetDestination(theDestination.transform.position);
                    if (theAgent.remainingDistance >= 0)
                    {
                        
                        endreach = true;
                    }
                }
                else
                {
                    theAgent.SetDestination(secondD.transform.position);
                    if (theAgent.remainingDistance >= 0)
                    {
                        endreach = false;
                    }
                }
            }

        }
        //npcAnimator.SetBool("IsMoving", false);

        //if (theAgent.remainingDistance >= 0.10f)
        //{
        //    npcAnimator.SetBool("IsMoving", false);
        //}
        //else
        //{
        //    npcAnimator.SetBool("IsMoving", true);
        //}
    }

    public Coroutine Wait(int time)
    {
        
        return StartCoroutine(Waituntile(time));
        
    }

    public IEnumerator Waituntile(int time)
    {
        
        System.Random random = new System.Random();
        theAgent.SetDestination(destionations[random.Next(0, destionations.Length - 1)].transform.position);
        currentdestion = destionations[random.Next(0, destionations.Length - 1)];
        yield return new WaitForSeconds(theAgent.remainingDistance/theAgent.speed * 1.2f);
        npcAnimator.SetBool("IsMoving", false);
        yield return new WaitForSeconds(time);
        randomPathing = true;
        npcAnimator.SetBool("IsMoving", true);

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

