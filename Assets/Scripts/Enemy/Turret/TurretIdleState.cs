using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretIdleState : TurretState
{
    public TurretIdleState(TurretController turret) : base(turret)
    {

    }

    public override void OnStateEnter()
    {
        //Debug.Log("Entering turret idle state");
        OnTurretStateEnter?.Invoke();
    }

    public override void OnStateExit()
    {
        //Debug.Log("Exiting turret idle state");
        OnTurretStateExit?.Invoke();
    }

    public override void OnStateUpdate()
    {
        if (turretController.IsPlayerVisible())
        {
            turretController.ChangeState(new TurretAttackState(turretController));
        }
    }
}
