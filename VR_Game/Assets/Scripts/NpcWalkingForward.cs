using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class NpcWalkingForward : MonoBehaviour
{

    [SerializeField] private Transform[] targets; //the list of targets the NPC will walk to
    int targetIndex; //the index of the current target
    NavMeshAgent agent; //the NavMeshAgent component of the NPC
    public Animator animator; //the animator component of the NPC


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
        targetIndex = -1;
        NextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance<=agent.stoppingDistance && !agent.pathPending)
        {
           
            animator.SetBool("Walking", false);
           
            NextPoint();
     
        }
    }

    // it is called to determine the next target and move the NPC to it
    void NextPoint()
    {

        int nextTarget = (targetIndex + 1) % targets.Length;

        targetIndex = nextTarget;
 
        animator.SetBool("Walking", true);

        agent.SetDestination(targets[targetIndex].position);
    }

    // it is called when the NPC makes a footstep - currently not implemented
    public void OnFootstep()
    {
        //Debug.LogError("Footstep");
    }

}
