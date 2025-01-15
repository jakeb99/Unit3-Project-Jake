using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour, IInteractable
{
    public Action OnPressed;
    public void StartInteraction()
    {
        OnPressed.Invoke();
        Debug.Log("Pressed Button");
    }

    public void StopInteraction()
    {
        Debug.Log("Button interaction stopped");
    }

}
