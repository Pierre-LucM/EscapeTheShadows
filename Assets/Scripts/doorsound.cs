using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class doorsound : MonoBehaviour
{
    public AudioSource CreakingDoor;
    public AudioClip CreakingDoorSound;
    public float rotationThreshold = 0.1f;
    private float lastRotation = 0f;
    public bool isGrab = false;
    public bool isLocked = true;
    public AudioSource doorLocked;
    public GameObject player;
    private StoreKey storeKey;
   private XRGrabInteractable grabInteractable;
    void Start()
    {
        if (player != null)
        {
            storeKey = player.GetComponent<StoreKey>();
        }
        else
        {
            isLocked = false;
        }
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (isGrab == false)
        {
            grabInteractable.enabled = true;
        }
    }

    public void playSoundOnDoor()
    {
        if (isLocked)
        {
            if (storeKey.keyCount == 0)
            {
                grabInteractable.enabled = false;
                doorLocked.Play();
                return;
            }
        }
        grabInteractable.enabled = true;
        isGrab = true;
        StartCoroutine(playSoundOnDoorCoroutine());
    }

    IEnumerator playSoundOnDoorCoroutine()
    {
        while (isGrab)
        {
            if (Mathf.Abs(transform.rotation.eulerAngles.y - lastRotation) > rotationThreshold)
            {
                CreakingDoor.PlayOneShot(CreakingDoorSound);
                lastRotation = transform.rotation.eulerAngles.y;
            }

            yield return new WaitForSeconds(0.1f);
        }

        if (isLocked)
        {
            unlockDoor();
            storeKey.UseKey();
        }
    }

    public void stopSoundOnDoor()
    {
        isGrab = false;
    }

    public void unlockDoor()
    {
        isLocked = false;
    }
    public void ToggleGrab()
    {
        isGrab = true;
    }
    public void ToggleUngrab()
    {
        isGrab = false;
    }
}