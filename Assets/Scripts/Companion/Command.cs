using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    // use custom constructer in child classes to pass member variables for commands

    protected CompanionController companionController;

    public void SetCompanionController(CompanionController companionController)
    {
        this.companionController = companionController;
    }

    // execute a command, adding it to the command queue
    public abstract void Execute();

    // cancels last command
    public abstract void Cancel();

    public abstract bool IsCommandComplete();


}
