using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    // the rb that can activate the presure plate
    [SerializeField] private Rigidbody triggerableRigidBody;  
    
    public UnityEvent OnPressurePlatePressedStart;
    public UnityEvent OnPressurePlatePressedEnd;
    private void OnTriggerEnter(Collider other)
    {
        if (triggerableRigidBody == other.attachedRigidbody)
        {
            OnPressurePlatePressedStart.Invoke();  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(triggerableRigidBody == other.attachedRigidbody)
        {
            OnPressurePlatePressedEnd.Invoke();
        }
    }
}
