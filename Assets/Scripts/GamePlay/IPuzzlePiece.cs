using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This interface is for any object that is a piece of a puzzle.
/// Each puzzle piece must be linked to a concrete puzzle and can check
/// if this puzzle piece is 'correct'
/// </summary>
public interface IPuzzlePiece
{
    //// optional
    //public void LinkToPuzzle(Puzzle p);

    // similar to IsPuzzleComplete() from puzzle class but for an indiv piece
    public bool IsCorrect();
}
