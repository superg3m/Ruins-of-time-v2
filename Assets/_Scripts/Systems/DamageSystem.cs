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
    public int playerStatusQuantity;

    public int monsterDamage;
    public int monsterBlock;
    public int monsterDodge;

    public void addPlayerDamage(int incDamage)
    {
        playerDamage += incDamage;
    }
    public void addPlayerBlock(int incBlock)
    {
        playerBlock += incBlock;
    }
    public void addPlayerDodge(int incDodge)
    {
        playerDodge += incDodge;
    }

    public void addMonsterDamage(int incDamage)
    {
        monsterDamage += incDamage;
    }
    public void addMonsterBlock(int incBlock)
    {
        monsterBlock += incBlock;
    }
    public void addMonsterDodge(int incDodge)
    {
        monsterDodge += incDodge;
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