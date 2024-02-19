using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ScreamerScript : MonoBehaviour
{
    [SerializeField] private GameObject screamer;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float SpawnDuration = 5f;
    private float _timer;
    private bool _isSpawned = false;
    public AudioClip scream;
    private AudioSource _audioSource;
    
    private void Start()
    {
      
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isSpawned)
            {
                _audioSource = GetComponent<AudioSource>();

                if (_audioSource == null)
                {
                    _audioSource = gameObject.AddComponent<AudioSource>();
                }
        
                _audioSource.clip = scream;
                SpawnScreamer();
            }
        }
    }

    IEnumerator DestroyScreamer(GameObject gameObjectToDestroy)
    {
        if (_isSpawned)
        {
            yield return new WaitForSeconds(_timer);
            
            Destroy(gameObjectToDestroy.transform.gameObject);
            _audioSource.Stop();
            _isSpawned = false;
        }
        else
        {
            yield return null;
        }
    }

    private void SpawnScreamer()
    {
        if (screamer != null)
        {   _audioSource.Play();
            GameObject screamerPrefab = Instantiate(screamer, spawnPoint.position, spawnPoint.rotation);
            screamerPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _isSpawned = true;
      
            _timer = SpawnDuration;
            StartCoroutine(DestroyScreamer(screamerPrefab));
        }
    }
}