using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random; //important

//if you use this code you are contractually obligated to like the YT video
public class RandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    public List<Transform> playerTransform;
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] private Transform _player;
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.destination = playerTransform[Random.Range(0, playerTransform.Count)].position;
    }


    void Update()
    {
    }

    private void FixedUpdate()
    {
        // check if player is in range
        // if player is in range, set destination to player and play audio
        // if player is not in range, set destination to random position and stop audio
        if (agent.destination == transform.position &&
            Vector3.Distance(agent.nextPosition, _player.position) > agent.radius)
        {
            agent.destination = playerTransform[Random.Range(0, playerTransform.Count)].position;
            _audioSource.Stop();
        }


        else if (Vector3.Distance(agent.nextPosition, _player.position) < agent.radius)
        {
       
            agent.speed = 10;
            agent.angularSpeed = 270;
            _audioSource.Play();
            agent.destination = _player.position;
        }
        agent.acceleration = 0.3f;

        agent.speed = 3.5f;
        agent.angularSpeed = 120;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.Play();
            agent.destination = other.transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude/2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.Stop();
            agent.destination = playerTransform[Random.Range(0, playerTransform.Count)].position;
        }
    }*/
}