using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLazer : MonoBehaviour
{
    [SerializeField] private Transform lazerOrgin;
    [SerializeField] private float maxLazerLength;

    private LineRenderer lr;
    private Ray lazerRaycast;
    private float currentLazerLen;

    private void Start()
    {
        // the starting max dist is the max lazer dist
        currentLazerLen = maxLazerLength;

        // set up line renderer
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, lazerOrgin.position);
        lr.SetPosition(1, lazerOrgin.position + lazerOrgin.forward * currentLazerLen);

        // set up raycast
        lazerRaycast = new Ray(lazerOrgin.position, lazerOrgin.forward);

    }

    private void SetLazerLen(float dist)
    {
        lr.SetPosition(1,lazerOrgin.position + lazerOrgin.forward * dist);
    }

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(lazerRaycast, out hit, currentLazerLen); // add layer mask?

        // if there is something colliding with the ray cast
        if(hit.collider)
        {   
            // set current distance to hit location and set the line renderer
            currentLazerLen = hit.distance;
            //lr.SetPosition(1, lazerOrgin.position + lazerOrgin.forward * currentLazerLen);
            SetLazerLen(currentLazerLen);
        } else
        {
            currentLazerLen = maxLazerLength;
            //lr.SetPosition(1, lazerOrgin.position + lazerOrgin.forward * currentLazerLen);
            SetLazerLen(currentLazerLen);
        }
    }
}
