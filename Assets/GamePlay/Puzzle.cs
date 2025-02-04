using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour
{
    protected IPuzzlePiece[] allPuzzlePieces;

    private void Awake()
    {
        allPuzzlePieces = GetComponentsInChildren<IPuzzlePiece>();
    }

    // an event to happen when puzzle is complete, recomended to be used for custom and specific things
    public UnityEvent OnPuzzleCompleted;

    // true when puzzle complete
    public bool isPuzzleComplete;

    // method to check the solution, see if puzzle is completed
    public abstract bool CheckSolution();

}
