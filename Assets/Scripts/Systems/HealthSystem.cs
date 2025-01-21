using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public Action<float> OnHealthChange;
    public Action OnDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;

        OnHealthChange?.Invoke(currentHealth);
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        OnHealthChange?.Invoke(currentHealth);

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
