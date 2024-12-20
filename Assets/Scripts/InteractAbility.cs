using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    [SerializeField] private LayerMask interactionFilter;
    [SerializeField] private Transform interactionTip;
    public void Interact()
    {
        Ray customRay = new Ray(interactionTip.position, interactionTip.forward);

        RaycastHit tempHit;
        if(Physics.Raycast(customRay, out tempHit, 5f, interactionFilter))
        {
            Debug.Log(tempHit.collider.name);
        } else
        {
            Debug.Log("Ray not hitting anything");
        }

        Debug.DrawRay(interactionTip.position, interactionTip.forward, Color.red);
    }
}
