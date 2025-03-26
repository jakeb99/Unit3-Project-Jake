using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretState
{
    protected TurretController turretController;

    public Action OnTurretStateEnter;
    public Action OnTurretStateExit;

    public TurretState(TurretController turret)
    {
        this.turretController = turret;
    }

    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    public abstract void OnStateUpdate();

}
