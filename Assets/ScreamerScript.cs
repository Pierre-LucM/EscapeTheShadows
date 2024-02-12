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
