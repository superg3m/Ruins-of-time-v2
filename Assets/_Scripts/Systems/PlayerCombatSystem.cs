using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Xml;
using UnityEngine.UI;

public class PlayerCombatSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;
    public DamageSystem damageSystem;
    public Dictionary<string, int> statusDictionary;

    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;
    public int totalStatusSelected;
    public int playerStatusQuantity;

    public void BlockDamage(int damageToBlock)
    {
        totalBlockSelected += damageToBlock;
    }
    public void DodgeDamage(int damageToDodge)
    {
        totalDodgeSelected += damageToDodge;
    }
    public void addDamage(int damageToAdd)
    {
        totalDamageSelected += damageToAdd;
    }
    public void addStatusQuantity(int quantity)
    {
        playerStatusQuantity += quantity;
    }

    public void SetData()
    {
        damageSystem.addPlayerDamage(totalDamageSelected);
        damageSystem.addPlayerBlock(totalBlockSelected);
        damageSystem.addPlayerDodge(totalDodgeSelected);
    }
    public void ClearData()
    {
        totalBlockSelected = 0;
        totalDamageSelected = 0;
        totalDodgeSelected = 0;
    }
}