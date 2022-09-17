using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class AICombatSystem : MonoBehaviour
{
    public HealthSystem playerHealth;
    public HealthSystem enemyHealth;
    public DamageSystem damageSystem;
    public StatusSystem playerStatus;

    public EnemySpawnCard enemyCard;

    public List<CurrentCard> cardsChosen;

    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;

    public int randomAttackChance;
    public int randomDefenseChance;
    public int randomStatusChance;

    public static bool isWaiting = false;

    int numberOfOffensive = 0;
    int numberOfDefensive = 0;
    int numberOfStatus = 0;

    void determineCardTypes()
    {
        for (int i = 0; i < enemyCard.handList.Count; i++)
        {
            string cardType = enemyCard.handList[i].GetComponent<CurrentCard>().classification;
            if (cardType == "Offensive") numberOfOffensive += 1;
            else if (cardType == "Defensive") numberOfDefensive += 1;
            else if (cardType == "Status") numberOfStatus += 1;
        }
    }
    private void Update()
    {
        if (cardsChosen.Count == 0 && !isWaiting)
        {
            ChooseCard();
        }
    }
    public void clearChoosenCards()
    {
        cardsChosen.Clear();
    }
    private void ChooseCard()
    {
        determineCardTypes();

        randomAttackChance = Random.Range(0, 51);
        randomDefenseChance = Random.Range(0, 21);
        randomStatusChance = Random.Range(0, 21);

        int chance = Random.Range(0, 101);
        if (numberOfOffensive > 0 && randomAttackChance >= chance)
        {
            for (int i = 0; i < enemyCard.handList.Count; i++)
            {
                string cardType = enemyCard.handList[i].GetComponent<CurrentCard>().classification;
                if (cardType == "Offensive")
                {
                    enemyCard.handList[i].GetComponent<CurrentCard>().setSelectionBool(true);
                    cardsChosen.Add(enemyCard.handList[i].GetComponent<CurrentCard>());
                }
            }
        }
        chance = Random.Range(0, 101);
        if (numberOfDefensive > 0 && randomDefenseChance >= chance)
        {
            for (int i = 0; i < enemyCard.handList.Count; i++)
            {
                string cardType = enemyCard.handList[i].GetComponent<CurrentCard>().classification;
                if (cardType == "Defensive")
                {
                    enemyCard.handList[i].GetComponent<CurrentCard>().setSelectionBool(true);
                    cardsChosen.Add(enemyCard.handList[i].GetComponent<CurrentCard>());
                }
            }
        }
        chance = Random.Range(0, 101);
        if (numberOfStatus > 0 && randomDefenseChance >= chance)
        {
            for (int i = 0; i < enemyCard.handList.Count; i++)
            {
                string cardType = enemyCard.handList[i].GetComponent<CurrentCard>().classification;
                if (cardType == "Status")
                {
                    enemyCard.handList[i].GetComponent<CurrentCard>().setSelectionBool(true);
                    cardsChosen.Add(enemyCard.handList[i].GetComponent<CurrentCard>());
                }
            }
        }
    }

    public void SetData()
    {
        isWaiting = true;
        for (int i = 0; i < cardsChosen.Count; i++)
        {
            string currentStatus = cardsChosen[i].status;
            int statusQuantity = cardsChosen[i].statusQuanity;

            totalDamageSelected += cardsChosen[i].attackValue;
            totalBlockSelected += cardsChosen[i].defenseValue;
            totalDodgeSelected += cardsChosen[i].dodgeValue;

            // Going to need to exclude heal
            if (currentStatus != "" && currentStatus != "Heal")
            {
                playerStatus.addStatuses(currentStatus, statusQuantity);
            }
            else if (currentStatus != "" && currentStatus == "Heal")
            {
                //playerHealth.addStatuses(currentStatus, statusQuantity);
            }
            cardsChosen[i].tag = "Selected";
        }
        playerHealth.addDamage(totalDamageSelected);
        enemyHealth.addBlock(totalBlockSelected);
        enemyHealth.addDodge(totalDodgeSelected);
    }
    
    public void ClearData()
    {
        totalBlockSelected = 0;
        totalDamageSelected = 0;
        totalDodgeSelected = 0;
    }
}