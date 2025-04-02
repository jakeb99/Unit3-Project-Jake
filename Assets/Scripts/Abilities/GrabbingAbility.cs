using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingAbility : MonoBehaviour
{
    [SerializeField] public Transform holdingHand;  // position object is held at
    private Rigidbody objectHeld;
    [SerializeField] private float objectHeldDrag;
    [SerializeField] private float objectHeldAngularDrag;
    [SerializeField] private float objectHeldMovementMultiplier;
    [SerializeField] private float throwMultiplier;
    [SerializeField] private Transform playerCamTrans;

    private void Update()
    {
        if (objectHeld && Vector3.Distance(holdingHand.position, objectHeld.transform.position) > 0.11f)
        {
            MoveObject();
        }
    }
    public void PickUpObject(Rigidbody toGrab)
    {
        if (objectHeld)
        {
            DropObject();
            return;
        }

        objectHeld = toGrab;
        toGrab.useGravity = false;
        toGrab.drag = objectHeldDrag;
        toGrab.angularDrag = objectHeldAngularDrag;
        toGrab.transform.position = holdingHand.position;

        //toGrab.isKinematic = true;
        //toGrab.transform.SetParent(holdingHand);
    }

    public void DropObject()
    {
        if (objectHeld)
        {
            objectHeld.useGravity = true;
            objectHeld.drag = 0;
            objectHeld.angularDrag = 0;
            objectHeld = null;

            //objectHeld.isKinematic = false;
            //objectHeld.transform.SetParent(null);
        }
    }

    public void MoveObject()
    {
        // move the object we are holding to direction holding hand is pointing
        Vector3 direction = holdingHand.position - objectHeld.position; // dest - current pos = direction
        objectHeld.AddForce(direction * objectHeldMovementMultiplier);
    }

    public void ThrowObject()
    {
        if (objectHeld)
        {
            Rigidbody throwObj = objectHeld;
            objectHeld.useGravity = true;
            objectHeld.drag = 0;
            objectHeld.angularDrag = 0;

            objectHeld = null;
            throwObj.angularVelocity = Vector3.zero;
            throwObj.velocity = throwObj.velocity * 0.5f;
            throwObj.AddForce(playerCamTrans.forward * throwMultiplier);
        }
    }
}
