using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;
    public DamageSystem damageSystem;

    public List<string> statusList;
    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;


    public void BlockDamage(int damageToBlock)
    {
        totalBlockSelected += damageToBlock;
    }
    public void DodgeDamage(int damageToDodge)
    {
        totalDodgeSelected += damageToDodge;
    }
    public void GatherDamage(int damageToAdd)
    {
        totalDamageSelected += damageToAdd;
    }
    public void GatherStatuses(string statusToAdd)
    {
        statusList.Add(statusToAdd);
    }
    public void RemoveStatus(string statusToRemove)
    {
        statusList.Remove(statusToRemove);
    }
    public void SetData()
    {
        damageSystem.SetPlayerDamage(totalDamageSelected);
        damageSystem.SetPlayerDodge(totalDodgeSelected);
        damageSystem.SetPlayerBlock(totalBlockSelected);
        for (int i = 0; i < statusList.Count; i++)
        {
            damageSystem.SetMonsterStatus(statusList[i]);
        }
    }
    public void ClearData()
    {
        totalBlockSelected = 0;
        totalDamageSelected = 0;
        totalDodgeSelected = 0;
        statusList.Clear();
    }
    public void ClearStatus()
    {
        statusList.Clear();
    }
}