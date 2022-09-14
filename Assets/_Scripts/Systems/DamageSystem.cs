using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;

    [SerializeField] private Button confirmButton;

    public int playerDamage;
    public int playerBlock;
    public int playerDodge;

    public int monsterDamage;
    public int monsterBlock;
    public int monsterDodge;

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
    public void CalculateResults(bool playerCheck)
    {
        confirmButton.interactable = false;
        if (playerCheck)
        {
            playerHealth.addBlock(playerBlock);
            playerHealth.addDodge(playerDodge);
            enemyHealth.addDamage(playerDamage);
            enemyHealth.Update();
        }
        else
        {
            enemyHealth.addBlock(monsterBlock);
            enemyHealth.addDodge(monsterDodge);
            playerHealth.addDamage(monsterDamage);
            playerHealth.Update();
        }
        playerDamage = 0;
        playerBlock = 0;
        playerDodge = 0;
        monsterBlock = 0;
        monsterDamage = 0;
        monsterDodge = 0;
    }
}