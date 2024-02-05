using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsound : MonoBehaviour
{
    public AudioSource CreakingDoor;
    public float rotationThreshold = 10f;
    private float lastRotation;
    
    void Update()
    {
        float currentRotation = transform.localRotation.y;
        if (Mathf.Abs(currentRotation - lastRotation) > rotationThreshold)
        {
            CreakingDoor.Play();
        } 
        lastRotation = currentRotation;
    }
}
