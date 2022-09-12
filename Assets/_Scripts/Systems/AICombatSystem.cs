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
    public SpawnCard card;
    public List<GameObject> handList;
    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;
    private List<string> possibleChoice;
    private GameObject enemySpawnPoints;
    public GameObject cardChosen;
    private int attackRate;
    private int defenseRate;

    private void Awake()
    {
        enemySpawnPoints = GameObject.Find("EnemySpawnPoint");
        handList = card.handList;
    }
    public void ChooseCard(int attackRate)
    {

        int randomNumber = Random.Range(1, 21);
        string decision = "";
        if (randomNumber <= attackRate)
        {
            decision = "Offensive";
        }
        bool cardMissing = true;
        for (int i = 0; i < handList.Count; i++)
        {
            if (handList[i].GetComponent<CurrentCard>().classificationText.text == decision) cardMissing = false;
            if (i == 3 && cardMissing)
            {
                enemySpawnPoints.GetComponent<SpawnCard>().buttonPress();
                i = 0;
            }
        }
        List<GameObject> numberOfChoices = new List<GameObject>();
        for (int i = 0; i < handList.Count; i++)
        {
            if (decision == handList[i].GetComponent<CurrentCard>().classificationText.text)
            {
                numberOfChoices.Add(handList[i]);
            }
        }
        if (numberOfChoices.Count > 1)
        {
            int position = Random.Range(1, numberOfChoices.Count + 1);
            cardChosen = handList[position];
            //            Destroy(handList[position]);
        }
        else
        {

        }
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