using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        playerHealth = PlayerInput.Instance.GetComponent<HealthSystem>();

        // subscribe to OnHealthChange event to update UI health text
        playerHealth.OnHealthChange += UpdateHealthText;
        playerHealth.OnDead += DisplayDeathScreen;

        // lambda function
        //playerHealth.OnDead += () =>
        //{
        //};
    }

    void DisplayDeathScreen()
    {

    }

    void UpdateHealthText(float healthToDisplay)
    {
        healthText.text = "Health: " + healthToDisplay.ToString("F2");
    }
}
