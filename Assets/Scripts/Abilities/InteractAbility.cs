using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    [SerializeField] private LayerMask interactionFilter;
    [SerializeField] private Transform interactionTip;
    [SerializeField] private GrabbingAbility grabbingAbility;
    public void Interact()
    {
        Ray customRay = new Ray(interactionTip.position, interactionTip.forward);

        RaycastHit tempHit;
        if (!Physics.Raycast(customRay, out tempHit, 5f, interactionFilter))
        {
            grabbingAbility.DropObject();
            return;
        }
        
        Debug.Log(tempHit.collider.name);

        // get the interactable componant 
        IInteractable interactFeature = tempHit.collider.GetComponent<IInteractable>();
        if (interactFeature != null)
        {
            interactFeature.StartInteraction();
        }
        else
        {
            grabbingAbility.PickUpObject(tempHit.rigidbody);
        }
    }
}
