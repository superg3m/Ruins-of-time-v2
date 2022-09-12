using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanCardData : MonoBehaviour
{
    public UseMenu useMenu;
    public PlayerCombatSystem combatSystem;
    public HealthSystem enemyHealth;
    public CurrentCard cardToSort;
    public Button confirmButton;

    public string currentStatus;
    public string description;
    public string type;


    int value;
    int totalDamageSelected;
    int totalBlockSelected;
    int totalDodgeSelected;

    private List<string> possibleStatusList = new List<string>() {"burn", "heal", "poison", "bleeding", "vulnerable"};

    private Dictionary<string, bool> statusDictionary = new Dictionary<string, bool>() {
        {"burn", false},
        {"heal", false},
        {"poison", false},
        {"bleeding", false},
        {"vulnerable", false}
    };

    private void Awake()
    {
        currentStatus = "";
        confirmButton = GameObject.Find("ConfirmButton").GetComponent<Button>();
        enemyHealth = GameObject.Find("EnemyHealthBar").GetComponent<HealthSystem>();
        combatSystem = GameObject.Find("CombatSystem").GetComponent<PlayerCombatSystem>();
    }
    private void Start()
    {
        confirmButton.onClick.AddListener(destoryObject);
    }

    public void checkForStatus()
    {
        for (int i = 0; i < possibleStatusList.Count; i++)
        {
            string statusCheck = possibleStatusList[i];
            statusDictionary[statusCheck] = description.Contains(statusCheck);
            if(statusDictionary[statusCheck] == true)
            {
                currentStatus = statusCheck;
                combatSystem.addStatuses(currentStatus);
                combatSystem.addDamage(value);
            }
        }
    }

    public void destoryObject()
    {
        if (gameObject.tag == "Selected") Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (useMenu.isUsingCard)
        {
            description = cardToSort.descriptionText.text;
            type = cardToSort.classificationText.text;
            value = cardToSort.value;

            if (type == "Offensive")
            {
                combatSystem.addDamage(value);
            }
            else if (type == "Defensive")
            {
                bool hasBlock = description.Contains("block");
                if (hasBlock)
                {
                    combatSystem.BlockDamage(value);
                }
                bool hasDodge = description.Contains("dodge");
                if (hasDodge)
                {
                    combatSystem.DodgeDamage(value);
                }
            }
            else if (type == "Status")
            {
                checkForStatus();
            }
            useMenu.setUsingBool(false);
        }

        if(useMenu.isCanceling)
        {
            combatSystem.RemoveStatus(currentStatus);

            if(combatSystem.totalDamageSelected > 0)
            {
                combatSystem.addDamage(-value);
            }

            if (combatSystem.totalBlockSelected > 0)
            {
                combatSystem.BlockDamage(-value);
            }

            if (combatSystem.totalDodgeSelected > 0)
            {
                combatSystem.DodgeDamage(-value);
            }
            
            useMenu.setCancelingBool(false);
        }
    }
}
