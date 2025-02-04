using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour, IPuzzlePiece
{
    // the rb that can activate the presure plate
    [SerializeField] private Rigidbody[] triggerableRigidbodies;
    [SerializeField] private bool canTriggerByAny;

    public UnityEvent OnPressurePlatePressedStart;
    public UnityEvent OnPressurePlatePressedEnd;

    private bool isPressed;
    
    private void OnTriggerEnter(Collider other)
    {
        foreach (Rigidbody rb in triggerableRigidbodies)
        {
            if (canTriggerByAny || rb == other.attachedRigidbody)
            {
                isPressed = true;
                OnPressurePlatePressedStart.Invoke();
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Rigidbody rb in triggerableRigidbodies)
        {
            if (canTriggerByAny || rb == other.attachedRigidbody)
            {
                OnPressurePlatePressedEnd.Invoke();
                isPressed = false;
                return;
            }
        }   
    }

    // will return true if there is a valid rb on the pressure plate
    public bool IsCorrect()
    {
        return isPressed;
    }
}
