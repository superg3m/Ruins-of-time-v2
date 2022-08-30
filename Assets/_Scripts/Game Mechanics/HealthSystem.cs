using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float lastHitTime = 5f;
    public float lastHitTimer;

    public float regenerationRate;


    public void Awake()
    {
        currentHealth = maxHealth;
        lastHitTimer = lastHitTime;
    }
    public void Update()
    {
        CheckTimeSinceLastHit();
        RegenerateHealth(regenerationRate * Time.deltaTime);
    }

    public void CheckTimeSinceLastHit()
    {
        lastHitTimer -= Time.deltaTime;
        if (lastHitTimer <= 0f) lastHitTimer = 0f;
    }
    public void RegenerateHealth(float regenerationAmount)
    {
        if (currentHealth < maxHealth && lastHitTimer == 0) currentHealth += regenerationAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
    public void RemoveHealth(float damage)
    {
        if((currentHealth - damage) >= 0)
        {
            currentHealth -= damage;
            lastHitTimer = lastHitTime;
        }
    }
    public void AddHealth(float amount)
    {
        if ((currentHealth + amount) <= maxHealth) currentHealth += amount;
        else if ((currentHealth + amount) > maxHealth)  currentHealth = maxHealth;
    }
}
