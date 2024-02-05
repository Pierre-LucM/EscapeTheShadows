using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light _light;
    private AudioSource _audioSource;
    void Start()
    {
        _light = GetComponent<Light>();
        _audioSource = GetComponent<AudioSource>();
        
    }
    public void LightOn()
    {
        _audioSource.Play();
        _light.enabled = true;
    }
    public void LightOff()
    {
        _audioSource.Play();
        _light.enabled = false;
    }
}
