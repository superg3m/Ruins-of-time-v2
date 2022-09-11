using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using System;

public class HealthSystem : MonoBehaviour
{
    public TMP_Text HealthText;
    public int maxHealth;
    public int currentHealth;
    public int currentBlock;

    public int regenerationRate;


    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Update()
    {
        RegenerateHealth(regenerationRate);
        
        if(currentBlock > 0) HealthText.text = String.Format("<color=green>{0}</color> + <color=blue>{1}</color> ", currentHealth, currentBlock);
        else
        {
            HealthText.text = String.Format("<color=green>{0}</color>", currentHealth);
        }
    }

    public void RegenerateHealth(int regenerationAmount)
    {
        if (currentHealth < maxHealth) currentHealth += regenerationAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
    public void RemoveHealth(int damage)
    {
        if((currentHealth - damage) >= 0)
        {
            currentHealth -= damage;
        }
    }
    public void AddHealth(int amount)
    {
        if ((currentHealth + amount) <= maxHealth) currentHealth += amount;
        else if ((currentHealth + amount) > maxHealth)  currentHealth = maxHealth;
    }
    public void AddBlock(int amount)
    {
        currentBlock += amount;
    }
}
