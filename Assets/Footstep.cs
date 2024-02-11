using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Footstep : MonoBehaviour
{
    public AudioSource footstep;
    public InputActionProperty moveInputAction;

    private bool isMoving;

    private void FixedUpdate()
    {
        if (moveInputAction != null && moveInputAction.action != null)
        {
            InputAction action = moveInputAction.action;
            Vector2 moveInput = action.ReadValue<Vector2>();

            // Determine if the player is moving based on input
            isMoving = (moveInput.x != 0 || moveInput.y != 0);

            // Play footstep sound if moving and not already playing
            if (isMoving && !footstep.isPlaying)
            {
                footstep.Play();
            }
            // Stop footstep sound if not moving
            else if (!isMoving && footstep.isPlaying)
            {
                footstep.Stop();
            }
        }
    }
    private void Update()
    {
        if (isMoving && footstep.isPlaying && !footstep.loop)
        {
            footstep.loop = true;
        }
        else if (!isMoving && footstep.isPlaying && footstep.loop)
        {
            footstep.loop = false;
        }
    }
}