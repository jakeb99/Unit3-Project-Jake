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
    private AttackAbility attackAbility;

    public void Awake()
    {

    }

    public void Start()
    {
        attackAbility = GetComponent<AttackAbility>();
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

    public void StartLazer()
    {
        // the starting max dist is the max lazer dist
        currentLazerLen = maxLazerLength;

        // set up line renderer
        lr.enabled = true;
        lr.SetPosition(0, lazerOrgin.position);
        SetLazerLen(currentLazerLen);

        // set up raycast
        lazerRaycast = new Ray(lazerOrgin.position, lazerOrgin.forward);
    }

    public void EndLazer()
    {
        lr.enabled = false;
    }

    private void SetLazerLen(float dist)
    {
        lr.SetPosition(1,lazerOrgin.position + lazerOrgin.forward * dist);
    }

    public void UpdateLazer()
    {
        RaycastHit hit;
        Physics.Raycast(lazerRaycast, out hit, currentLazerLen); // add layer mask?

        // if there is something colliding with the ray cast
        if (hit.collider)
        {
            if (hit.collider.CompareTag("Player"))
            {
                attackAbility.StartAttack(hit.collider.gameObject.transform);
            }
            // set current distance to hit location and set the line renderer
            currentLazerLen = hit.distance;
            //lr.SetPosition(1, lazerOrgin.position + lazerOrgin.forward * currentLazerLen);
            SetLazerLen(currentLazerLen);
        }
        else
        {
            attackAbility.StopAttack();
            currentLazerLen = maxLazerLength;
            //lr.SetPosition(1, lazerOrgin.position + lazerOrgin.forward * currentLazerLen);
            SetLazerLen(currentLazerLen);
        }
    }
}
