using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light _light;
    private AudioSource _audioSource;
    [SerializeField]
    private InputActionProperty _lightAction;
    [SerializeField]
    private bool _isOn; 
    
    public Light light;
    public float minTime;
    public float maxTime;
    public float Timer;
    void Start()
    {
        Timer = Random.Range(minTime, maxTime);
        _audioSource = GetComponent<AudioSource>();
    }
    public void LightOn()
    {
        _audioSource.Stop(); // Stop any currently playing audio
        _audioSource.Play();
        _light.enabled = true;
    }
    public void LightOff()
    {
        _audioSource.Stop(); // Stop any currently playing audio
        _audioSource.Play();
        _light.enabled = false;
    }

    public void DropLight()
    {
        _light.enabled = true;
    }
    
    public void PickupLight()
    {
        _light.enabled = _isOn;
    }
    void Update()
    {
        if (_lightAction.action.triggered)
        {
            _isOn = !_isOn;
            if (_isOn)
            {
                LightOn();
            }
            else
            {
                LightOff();
            }
        }

        if (_isOn)
        {
            FlickerLight();
        }
    }
    
    void FlickerLight()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer<= 0)
        {
            light.enabled = !light.enabled;
            Timer = Random.Range(minTime, maxTime);
        }
    }
}
