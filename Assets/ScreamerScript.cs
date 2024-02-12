using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerScript : MonoBehaviour
{
    [SerializeField] private GameObject screamer;
    [SerializeField] private Transform  spawnPoint;
    [SerializeField] private float SpawnDuration = 5f;
    private float timer;
    private bool isSpawned = false;
    public AudioClip scream;
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.clip = scream;
    }
    void Update()
    {
        if (isSpawned)
        {
            timer -= Time.deltaTime;

            if (timer <=0)
            {
                DestroyScreamer();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnScreamer();
            timer = SpawnDuration;
            isSpawned = true;
            audioSource.PlayOneShot(scream);
        }
    }
    
    private void SpawnScreamer()
    {
        if (screamer != null)
        {
            Instantiate(screamer, spawnPoint.position, spawnPoint.rotation);
        }
    }
    
    private void DestroyScreamer()
    {
        if (isSpawned)
        {
            Destroy(screamer);
            isSpawned = false;
        }
    }
}
