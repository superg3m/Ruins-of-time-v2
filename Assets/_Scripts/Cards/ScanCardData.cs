using Newtonsoft.Json.Linq;
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
    public string type;

    int statusQuantity;
    int attackValue;
    int defenseValue;
    int dodgeValue;

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

    public void destoryObject()
    {
        if (gameObject.tag == "Selected") Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (useMenu.isUsingCard)
        {
            type = cardToSort.classificationText.text;
            attackValue = cardToSort.attackValue;
            defenseValue = cardToSort.defenseValue;
            dodgeValue = cardToSort.dodgeValue;
            currentStatus = cardToSort.status;
            statusQuantity = cardToSort.statusQuanity;

            combatSystem.addDamage(attackValue);

            combatSystem.BlockDamage(defenseValue);

            combatSystem.DodgeDamage(dodgeValue);

            if (currentStatus != "")
            {
                combatSystem.addStatuses(currentStatus, statusQuantity);
            }
            useMenu.setUsingBool(false);
        }

        if(useMenu.isCanceling)
        {
            if(currentStatus != "") combatSystem.RemoveStatus(currentStatus, statusQuantity);

            if (combatSystem.totalDamageSelected > 0) combatSystem.addDamage(-attackValue);

            if (combatSystem.totalBlockSelected > 0) combatSystem.BlockDamage(-defenseValue);

            if (combatSystem.totalDodgeSelected > 0) combatSystem.DodgeDamage(-dodgeValue);
         
            useMenu.setCancelingBool(false);
        }
    }
}
