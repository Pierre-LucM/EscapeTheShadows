using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsound : MonoBehaviour
{
    public AudioSource CreakingDoor;
    public float rotationThreshold = 0.01f;
    private float lastRotation;
    
    void Update()
    {       
        Debug.Log(Mathf.Abs(transform.rotation.eulerAngles.y - lastRotation));
          if (Mathf.Abs(transform.rotation.eulerAngles.y - lastRotation) > rotationThreshold)
          {
                CreakingDoor.Play();
          }
          lastRotation = transform.rotation.eulerAngles.y;
    }
}
