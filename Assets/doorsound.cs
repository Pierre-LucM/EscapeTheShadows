using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsound : MonoBehaviour
{
    public AudioSource CreakingDoor;
    public AudioClip CreakingDoorSound;
    public float rotationThreshold = 0.1f;
    private float lastRotation=0f;
    
    void Update()
    {       
        if (Mathf.Abs(transform.rotation.eulerAngles.y - lastRotation) > rotationThreshold)
        {
            CreakingDoor.PlayOneShot(CreakingDoorSound);
            lastRotation = transform.rotation.eulerAngles.y;
        }
    }
}
