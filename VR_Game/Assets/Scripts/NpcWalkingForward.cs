using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class NpcWalkingForward : MonoBehaviour
{


    [SerializeField] private Transform[] targets;
    int targetIndex;
    NavMeshAgent agent;
    public Animator animator;
    float timer;
    float waitTime;
    float waitTimeMin = 0f;
    float waitTimeMax = 1f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
        targetIndex = -1;

        timer = 0;
        NextPoint();

    }

    // Update is called once per frame
    void Update()
    {

        
        if(agent.remainingDistance<=agent.stoppingDistance && !agent.pathPending)
        {
            //Debug.LogError("!!!!");
            animator.SetBool("Walking", false);
            //timer = timer +Time.deltaTime;
            //if (timer >= waitTime)
            //{
            NextPoint();
            //}

        }
    }

    void NextPoint()
    {

        timer = 0;
        //waitTime = Random.Range(waitTimeMin, waitTimeMax);

        int nextTarget = (targetIndex + 1) % targets.Length;
        //Debug.LogError(nextTarget);
        targetIndex = nextTarget;
 
        animator.SetBool("Walking", true);

        agent.SetDestination(targets[targetIndex].position);
    }

}
