using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningScreamer : MonoBehaviour
{
    public AudioSource Screamer;
    public AudioClip ScreamerSound;
    public GameObject Door;
    public HingeJoint Hinge;
    private bool isOpening = false;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // open the door
            if (!isOpening && !isOpen)
            {
                StartCoroutine(OpenDoorSmoothly());
            }
        }
    }
    IEnumerator OpenDoorSmoothly()
    {
        isOpening = true;
        Transform doorTransform = Door.transform;
        float targetAngle = 180f;  // Adjust this value based on how wide you want the door to open
        float duration = 5.0f;    // Adjust this value to control the opening speed

        float startAngle = doorTransform.rotation.eulerAngles.y;
        float elapsedTime = 0f;
        Screamer.PlayOneShot(ScreamerSound); // Play the sound
        while (elapsedTime < duration)
        {
          
            float angle = Mathf.Lerp(startAngle, targetAngle, elapsedTime / duration);
           doorTransform.RotateAround(Hinge.connectedAnchor, new Vector3(0,1,0), angle- doorTransform.rotation.eulerAngles.y);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //doorTransform.rotation = Quaternion.Euler(0, targetAngle, 0);
        isOpening = false;
        isOpen = true;
    }
}
