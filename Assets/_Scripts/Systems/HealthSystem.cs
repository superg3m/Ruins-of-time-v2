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
    public int currentDamage;

    int cacheOne;
    int cacheTwo;

    public int regenerationRate;


    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Update()
    {
        HealthText.text = String.Format("<color=green>{0}</color> + <color=blue>{1}</color> + <color=white>{2}</color>", currentHealth, currentBlock, currentDodge);
    }

    public void calculateValues()
    {
        cacheOne = currentDodge;
        cacheTwo = currentDamage;

        currentDamage = (cacheTwo - cacheOne) > 0 ? (cacheTwo - cacheOne) : 0;

        currentDodge = (cacheOne - cacheTwo) > 0 ? (cacheOne - cacheTwo) : 0;

        cacheOne = currentBlock;
        cacheTwo = currentDamage;

        currentDamage = (cacheTwo - cacheOne) > 0 ? (cacheTwo - cacheOne) : 0;
        currentBlock = (cacheOne - cacheTwo) > 0 ? (cacheOne - cacheTwo) : 0;
        
        currentHealth -= currentDamage;
        currentDamage = 0;
    }

    public void clearData()
    {
        currentBlock = 0;
        currentDodge = 0;
    }
    public void addDamage(int damage)
    {
        currentDamage += damage;
    }
    public void addHealth(int amount)
    {
        if ((currentHealth + amount) <= maxHealth) currentHealth += amount;
        else if ((currentHealth + amount) > maxHealth)  currentHealth = maxHealth;
    }
    public void addBlock(int amount)
    {
        currentBlock += amount;
    }
    public void addDodge(int amount)
    {
        currentDodge += amount;
    }
}
