using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light light;

    public float minTime;
    public float maxTime;
    public float Timer;
    void Start()
    {
        Timer = Random.Range(minTime, maxTime);
    }

    
    void Update()
    {
        
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
