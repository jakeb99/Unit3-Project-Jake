using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretAttackState : TurretState
{
    public TurretAttackState(TurretController turret) : base(turret)
    {

    }

    public override void OnStateEnter()
    {
        //Debug.Log("Entering turret attack state");
        turretController.turretlazer.StartLazer();

        // invoke event to do things like change light of turret to red
        OnTurretStateEnter?.Invoke();

    }

    public override void OnStateExit()
    {
        //Debug.Log("Exiting turret attack state");
        turretController.turretlazer.EndLazer();
        OnTurretStateExit?.Invoke();
    }

    public override void OnStateUpdate()
    {
        if (!turretController.IsPlayerVisible())
        {
            turretController.ChangeState(new TurretIdleState(turretController));
        } else
        {
            // activate lazer
            turretController.turretlazer.UpdateLazer();
        }
    }
}
