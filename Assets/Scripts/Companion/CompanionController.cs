using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// this class implements the command design pattern
public class CompanionController : MonoBehaviour
{
    [SerializeField] private Queue<Command> commandQueue = new Queue<Command>();

    private NavMeshAgent agent;
    Command currentCommand;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Debug.Log(agent.pathStatus);
        //if (commandQueue.Count > 0)
        //{
        //    commandQueue.Peek().Execute();
        //    if (commandQueue.Peek().IsCommandComplete())
        //    {
        //        FinishCommand(); // when the command is done we remove it from queue
        //    }
        //}

        if (currentCommand != null && !currentCommand.IsCommandComplete()) return;

        if (commandQueue.Count == 0) return;

        currentCommand = commandQueue.Dequeue();
        currentCommand.Execute();
    }

    public void GiveCommand(Command newCommand)
    {
        newCommand.SetCompanionController(this);
        commandQueue.Enqueue(newCommand);
    }

    public void FinishCommand()
    {
        commandQueue.Dequeue();
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }
}
