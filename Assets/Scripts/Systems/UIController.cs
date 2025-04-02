using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private GameController gameController;
    [SerializeField] private RunTimer runTimer;
    [SerializeField] private GameObject FinishGameScreen;
    [SerializeField] private GameObject playerHUD;

    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private TextMeshProUGUI currentTimerText;
    [SerializeField] private TextMeshProUGUI totalTimerText;

    [SerializeField] private TextMeshProUGUI endScreenLevelTimeText;

    private void Start()
    {
        playerHealth = PlayerInput.Instance.GetComponent<HealthSystem>();

        // hide player hud
        playerHUD.SetActive(false);

        // subscribe to OnHealthChange event to update UI health text
        playerHealth.OnHealthChange += UpdateHealthText;
        playerHealth.OnDead += ResetLevel;

        // sub to OnTimerChange events
        runTimer.OnCurrentTimerChange += UpdateCurrentTimerText;
        runTimer.OnTotalTimerChange += UpdateTotalTimerText;
        runTimer.OnTotalTimerChange += UpdateEndScreenLevelTimeText;

        playerHealth.OnDead += ResetLevel;
    }

    void DisplayDeathScreen()
    {

    }

    void UpdateHealthText(float healthToDisplay)
    {
        healthText.text = "Health: " + healthToDisplay.ToString("F2");
    }

    void UpdateCurrentTimerText(float time)
    {
        currentTimerText.text = $"Current: {time.ToString("F2")}s";
    }

    void UpdateTotalTimerText(float time)
    {
        totalTimerText.text = $"Total: {time.ToString("F2")}s";
    }

    void UpdateEndScreenLevelTimeText(float time)
    {
        endScreenLevelTimeText.text = $"{time.ToString("F2")}";
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }

    public void DisplayFinishScreen()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        FinishGameScreen.SetActive(true);
    }

    public void HideFinishScreen()
    {
        FinishGameScreen.SetActive(false);
    }

    public void ShowHUD()
    {
        playerHUD.SetActive(true);
    }

}
