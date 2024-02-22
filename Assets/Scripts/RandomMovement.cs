using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important

//if you use this code you are contractually obligated to like the YT video
public class RandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    public Transform playerTransform;
    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        agent.destination = playerTransform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    
}
