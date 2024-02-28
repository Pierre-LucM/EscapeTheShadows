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
    public float minTime;
    public float maxTime;
    public float Timer;
    private bool _isGrabbed;
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
        if (_lightAction.action.triggered && _isGrabbed)
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
         //   light.enabled = !light.enabled;
            StartCoroutine(ToggleLight(Random.Range(2,6)));
        }
    }
    
    IEnumerator ToggleLight(int toggleNumber)
    {
        for (int i = 0; i < toggleNumber; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 1.5f));
            _light.enabled = !_light.enabled;
        }
        Timer = Random.Range(minTime, maxTime);
        _light.enabled = true;
        yield return null;
    }
    public void GrabLight()
    {
        _isGrabbed = true;
    }
    public void ReleaseLight()
    {
        _isGrabbed = false;
    }
}
