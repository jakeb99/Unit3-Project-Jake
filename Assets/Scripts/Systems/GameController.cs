using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnGameStart = new UnityEvent();
    public UnityEvent OnFinalPuzzleCompleted = new UnityEvent();

    [SerializeField] private Puzzle finalPuzzle;

    private Puzzle currentPuzzle;
    [SerializeField] private Puzzle[] allPuzzles;

    private void Start()
    {
        OnGameStart?.Invoke();
    }

    public void StartGame()
    {
        
        //finalPuzzle.OnPuzzleCompleted.AddListener(GameCompleted);
    }

    public void GameCompleted()
    {

        OnFinalPuzzleCompleted?.Invoke();

    }


}
