using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomPuzzle : Puzzle
{
    // an event to happen when the player enters/exits the room
    public UnityEvent OnPlayerEnterRoom;
    public UnityEvent OnPlayerExitRoom;

    private bool isPuzzleActive = false;
    

    private void Update()
    {
        if (this.isPuzzleActive)
        {
            if (CheckSolution() && !isPuzzleComplete)
            {
                OnPuzzleCompleted?.Invoke();
                isPuzzleComplete = true;
                Debug.Log("Puzzle completed!");
                this.enabled = false;   // this will disable the script so then update is no longer being called
            }
        }
    }

    public override bool CheckSolution()
    {
        foreach (IPuzzlePiece p in allPuzzlePieces)
        {
            if (!p.IsCorrect())
            {
                return false;
            }
        }

        return true;
    }

    // this could help with optimization
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            isPuzzleActive = true;
            OnPlayerEnterRoom?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPuzzleActive = false;
            OnPlayerExitRoom?.Invoke();
        }
        
    }
    
}
