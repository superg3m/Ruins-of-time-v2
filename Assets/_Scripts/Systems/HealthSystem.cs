using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using System;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public TMP_Text HealthText;
    public int maxHealth;
    public int currentHealth;
    public int currentBlock;
    public int currentDodge;
    public int currentDamage;

    public bool vulnerable;

    int cacheOne;
    int cacheTwo;

    public int regenerationRate;


    public void Awake()
    {
        currentHealth = maxHealth;
    }
    private void OnEnable()
    {
        EventTesting.onHit += addHealth;
    }
    public void OnDisable()
    {
        
    }
    public void Update()
    {
        string str = String.Format("<color=green>{0}</color>", currentHealth);
        if (currentBlock != 0)
        {
            str += String.Format(" + <color=blue>{0}</color>", currentBlock);
        }
        if (currentDodge != 0)
        {
            str += String.Format(" + <color=white>{0}</color>", currentDodge);
        }
        HealthText.text = str;
        if(currentHealth <= 0) {SceneManager.LoadScene("GameOverLose");}
    }

    public void calculateValues()
    {
        if (vulnerable) 
        {
            Debug.Log(this.gameObject.name + " current damage: " + currentDamage);
            currentDamage *= 2;
            Debug.Log(this.gameObject.name + " doubled current damage: " + currentDamage);
        }   
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
        vulnerable = false;
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
