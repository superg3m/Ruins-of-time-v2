using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class PlayerCombatSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;
    public DamageSystem damageSystem;


    //  Status list needs to be a dictionary to track quanity

    private List<string> possibleStatusList = new List<string>() {"Burn", "Heal", "Poison", "Bleeding", "Vulnerable", "Retain Block"};
    public List<string> statusTracker = new List<string>();
    public Dictionary<string, int> statusDictionary = new Dictionary<string, int>()
    {
        {"Burn", 0},
        {"Heal", 0},
        {"Poison", 0},
        {"Bleeding", 0},
        {"Vulnerable", 0},
        {"Retain Block", 0}
    };

    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;

    private void Start()
    {

    }
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
    public void addStatuses(string statusToAdd, int quanity)
    {
        statusTracker.Add(String.Format("{0} {1}x", statusToAdd, quanity));
    }
    public void RemoveStatus(string statusToRemove, int quanity)
    {
        statusTracker.Remove(String.Format("{0} {1}x", statusToRemove, quanity));
    }

    public void SetData()
    {
        damageSystem.SetPlayerDamage(totalDamageSelected);
        damageSystem.SetPlayerDodge(totalDodgeSelected);
        damageSystem.SetPlayerBlock(totalBlockSelected);
        for (int i = 0; i < statusDictionary.Count; i++)
        {
            string status = possibleStatusList[i];
        }
    }
    public void ClearData()
    {
        totalBlockSelected = 0;
        totalDamageSelected = 0;
        totalDodgeSelected = 0;
        statusDictionary.Clear();
    }
    public void ClearStatus()
    {
        statusDictionary.Clear();
    }
}