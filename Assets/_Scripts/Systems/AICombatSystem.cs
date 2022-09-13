using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class AICombatSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;
    public DamageSystem damageSystem;
    public List<string> statusList;
    public EnemySpawnCard card;
    public GameObject hand;
    public GameObject cardChosen;

    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;

    private List<string> possibleStatusList = new List<string>() { "Burn", "Heal", "Poison", "Bleeding", "Vulnerable", "Retain Block" };
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

    private void Awake()
    {
        hand = GameObject.Find("EnemyHand");
    }
    public void ChooseCard(int attackRate)
    {
        
        int randomNumber = Random.Range(1, 21);
        string decision = "";
        bool searching = true;
        if (randomNumber <= attackRate)
        {
            decision = "Offensive";
        }
        else
        {
            decision = "Defensive";
        }
        Debug.Log(decision);
        while (searching)
        {
            if (decision == "Offensive")
            {
                bool cardMissing = true;
                for (int i = 0; i < card.handList.Count; i++)
                {
                    if (card.handList[i].GetComponent<CurrentCard>().classification == decision)
                    {
                        cardMissing = false;
                    }
                    if (i == 2 && cardMissing)
                    {
                        decision = "Defensive";
                        break;
                    }
                }
                if (!cardMissing)
                {
                    int randomChoice = Random.Range(0, 3);
                    while (card.handList[randomChoice].GetComponent<CurrentCard>().classification != decision)
                    {
                        randomChoice = Random.Range(0, 3);
                    }
                    if (card.handList[randomChoice].GetComponent<CurrentCard>().classification == decision)
                    {
                        cardChosen = card.handList[randomChoice];
                        totalDamageSelected = cardChosen.GetComponent<CurrentCard>().attackValue;
                        string status = cardChosen.GetComponent<CurrentCard>().status;
                        damageSystem.SetMonsterDamage(totalDamageSelected);
                        statusTracker.Add(status);
                        damageSystem.SetPlayerStatus(status);
                        searching = false;
                    }
                }
            }
            if (decision == "Defensive")
            {
                bool cardMissing = true;
                for (int i = 0; i < card.handList.Count; i++)
                {
                    if (card.handList[i].GetComponent<CurrentCard>().classification == decision)
                    {
                        cardMissing = false;
                    }
                    if (i == 2 && cardMissing)
                    {
                        decision = "Offensive";
                        break;
                    }
                }
                if (!cardMissing)
                {
                    int randomChoice = Random.Range(0, 3);
                    while (card.handList[randomChoice].GetComponent<CurrentCard>().classification != decision)
                    {
                        randomChoice = Random.Range(0, 3);
                    }
                    if (card.handList[randomChoice].GetComponent<CurrentCard>().classification == decision)
                    {
                        cardChosen = card.handList[randomChoice];
                        totalDodgeSelected = cardChosen.GetComponent<CurrentCard>().dodgeValue;
                        totalBlockSelected = cardChosen.GetComponent<CurrentCard>().defenseValue;
                        damageSystem.SetMonsterDodge(totalDodgeSelected);
                        damageSystem.SetMonsterBlock(totalBlockSelected);
                        searching = false;
                    }
                }
            }
        }
        
    }
    public void clearStatusTracker()
    {
        statusTracker.Clear();
    }
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
    public void SetData()
    {
        damageSystem.SetMonsterDamage(totalDamageSelected);
        damageSystem.SetMonsterDodge(totalDodgeSelected);
        damageSystem.SetMonsterBlock(totalBlockSelected);
        for (int i = 0; i < statusList.Count; i++)
        {
            damageSystem.SetPlayerStatus(statusList[i]);
        }
    }
}