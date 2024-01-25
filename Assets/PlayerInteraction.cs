using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private bool isGrabbingLeft;
    [SerializeField]
    private bool isGrabbingRight;
    [SerializeField]
    private GameObject doorParent;
    
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    public InputActionProperty leftHandPositionAction;
    public InputActionProperty rightHandPositionAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rightHandPositionAction.action.ReadValue<Vector3>());
        Debug.Log(leftHandPositionAction.action.ReadValue<Vector3>());
        float leftGripValue = leftHandAnimator.GetFloat("Grip");
        float rightGripValue = rightHandAnimator.GetFloat("Grip");
        if (leftGripValue > 0.5f)
        {
            this.isGrabbingLeft = true;
        }
        else
        {
            this.isGrabbingLeft = false;
        }
        if (rightGripValue > 0.5f)
        {
            this.isGrabbingRight = true;
        }
        else
        {
            this.isGrabbingRight = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            if(this.isGrabbingLeft || this.isGrabbingRight)
            {
                float leftHandX = leftHandPositionAction.action.ReadValue<Vector3>().x;
                float rightHandX = rightHandPositionAction.action.ReadValue<Vector3>().x;
                float leftHandY = leftHandPositionAction.action.ReadValue<Vector3>().y;
                float rightHandY = rightHandPositionAction.action.ReadValue<Vector3>().y;
                float leftHandZ = leftHandPositionAction.action.ReadValue<Vector3>().z;
                float rightHandZ = rightHandPositionAction.action.ReadValue<Vector3>().z;
                float leftHandDistance = Math.Abs(leftHandX - leftHand.transform.position.x) + Math.Abs(leftHandY - leftHand.transform.position.y) + Math.Abs(leftHandZ - leftHand.transform.position.z);
                float rightHandDistance = Math.Abs(rightHandX - rightHand.transform.position.x) + Math.Abs(rightHandY - rightHand.transform.position.y) + Math.Abs(rightHandZ - rightHand.transform.position.z);
               Debug.Log(leftHandDistance);
               Debug.Log(rightHandDistance);
                this.doorParent.transform.parent.Rotate(0.0f,isGrabbingLeft? this.doorParent.transform.rotation.y+leftHandDistance:this.doorParent.transform.parent.rotation.y+rightHandDistance , 1.0f);
            }
        }
    }
}

