using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;

    public int playerDamage;
    private int playerBlock;
    private int playerDodge;

    private int monsterDamage;
    private int monsterBlock;
    private int monsterDodge;

    public void SetPlayerDamage(int incDamage)
    {
        playerDamage += incDamage;
    }
    public void SetPlayerBlock(int incBlock)
    {
        playerBlock += incBlock;
    }
    public void SetPlayerDodge(int incDodge)
    {
        playerDodge += incDodge;
    }
    public void SetPlayerStatus(string status)
    {

    }
    public void SetMonsterDamage(int incDamage)
    {
        monsterDamage += incDamage;
    }
    public void SetMonsterBlock(int incBlock)
    {
        monsterBlock += incBlock;
    }
    public void SetMonsterDodge(int incDodge)
    {
        monsterDodge += incDodge;
    }
    public void SetMonsterStatus(string status)
    {

    }
    public void CalculateResults()
    {
        int finalPlayerDamage = playerDamage - (monsterBlock + monsterDodge);
        if (finalPlayerDamage < 0)
        {
            finalPlayerDamage = 0;
        }
        playerHealth.AddBlock(playerBlock);
        enemyHealth.RemoveHealth(finalPlayerDamage);
        enemyHealth.Update();
        playerDamage = 0;
        playerBlock = 0;
        playerDodge = 0;
        monsterBlock = 0;
        monsterDamage = 0;
        monsterDodge = 0;
    }
}