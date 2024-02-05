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
            Screamer.PlayOneShot(ScreamerSound); 
            if (!isOpening)
            {
                StartCoroutine(OpenDoorSmoothly());
            }
        }
    }
    IEnumerator OpenDoorSmoothly()
    {
        isOpening = true;
        Transform doorTransform = Door.transform;
        float targetAngle = 90f;  // Adjust this value based on how wide you want the door to open
        float duration = 1.0f;    // Adjust this value to control the opening speed

        float startAngle = doorTransform.rotation.eulerAngles.y;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float angle = Mathf.Lerp(startAngle, targetAngle, elapsedTime / duration);
           doorTransform.RotateAround(Hinge.connectedAnchor+Hinge.anchor, new Vector3(0,1,0), angle - doorTransform.rotation.eulerAngles.y);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //doorTransform.rotation = Quaternion.Euler(0, targetAngle, 0);
        isOpening = false;
    }
}
