using System;
using UnityEngine;

public class RunTimer : MonoBehaviour
{
    [SerializeField] float totalTime;
    [SerializeField] float currentTime;
    bool isTimerOn;

    public Action<float> OnCurrentTimerChange;
    public Action<float> OnTotalTimerChange;

    private void Start()
    {
        // todo: LOAD OBJECT FROM SAVE FILE
        totalTime = 0f;
        currentTime = 0f;
        OnCurrentTimerChange?.Invoke(currentTime);
        OnTotalTimerChange?.Invoke(totalTime);
        isTimerOn = false;
    }

    private void Update()
    {
        if (isTimerOn)
        {
            currentTime += Time.deltaTime;
            OnCurrentTimerChange?.Invoke(currentTime);
        }
        else if (!isTimerOn)
        {
            totalTime += currentTime;
            currentTime = 0f;
            OnCurrentTimerChange?.Invoke(currentTime);
            OnTotalTimerChange?.Invoke(totalTime);
        }
        //Debug.Log($"Total Time: {totalTime}\nCurrentTime: {currentTime}");
    }

    public void StartTimer()
    {
        isTimerOn = true;
    }

    public void StopTimer() 
    { 
        isTimerOn = false; 
    }

    public void ResetCurrentTimer()
    {
        currentTime = 0f;
    }

    public void RestTotalTimer() { currentTime = 0f; }

    public float GetTotalTime()
    {
        return totalTime;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
