using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;

    private int playerDamage;
    private int playerBlock;
    private int playerDodge;

    private int monsterDamage;
    private int monsterBlock;
    private int monsterDodge;

    public void SetPlayerData(int incDamage, int incBlock, int incDodge)
    {
        playerDamage = incDamage;
        playerBlock = incBlock;
        playerDodge = incDodge;
    }

    public void SetMonsterData(int incDamage, int incBlock, int incDodge)
    {
        monsterDamage = incDamage;
        monsterBlock = incBlock;
        monsterDodge = incDodge;
    }
    public void CalculateResults()
    {
        int finalPlayerDamage = playerDamage - (monsterBlock + monsterDodge);
        if (finalPlayerDamage > 0)
        {

        }
    }
}
