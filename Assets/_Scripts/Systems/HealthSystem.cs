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
    public int currentDodge;

    public int regenerationRate;


    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Update()
    {
        RegenerateHealth(regenerationRate);

        HealthText.text = String.Format("<color=green>{0}</color> + <color=blue>{1}</color> + <color=white>{2}</color>", currentHealth, currentBlock, currentDodge);
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
    public void AddDodge(int amount)
    {
        currentDodge += amount;
    }
}
