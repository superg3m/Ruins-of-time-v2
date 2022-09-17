using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanCardData : MonoBehaviour
{
    public UseMenu useMenu;
    public PlayerCombatSystem combatSystem;
    public StatusSystem enemyStatus;
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
        enemyStatus = GameObject.Find("EnemyHealthBar").GetComponent<StatusSystem>();
        combatSystem = GameObject.Find("CombatSystem").GetComponent<PlayerCombatSystem>();
    }
    private void Start()
    {
        confirmButton.onClick.AddListener(destroyObject);
    }

    public void destroyObject()
    {
        if (gameObject.tag == "Selected") Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        type = cardToSort.classificationText.text;
        attackValue = cardToSort.attackValue;
        defenseValue = cardToSort.defenseValue;
        dodgeValue = cardToSort.dodgeValue;
        currentStatus = cardToSort.status;
        statusQuantity = cardToSort.statusQuanity;
        if (useMenu.isUsingCard)
        {
            combatSystem.addDamage(attackValue);

            combatSystem.BlockDamage(defenseValue);

            combatSystem.DodgeDamage(dodgeValue);

            if (currentStatus != "")
            {
                combatSystem.addStatusQuantity(statusQuantity);
                enemyStatus.addStatuses(currentStatus, statusQuantity);
            }
            useMenu.setUsingBool(false);
        }

        if(useMenu.isCanceling)
        {
            if(currentStatus != "") enemyStatus.removeStatus(currentStatus, statusQuantity);

            if (combatSystem.totalDamageSelected > 0) combatSystem.addDamage(-attackValue);

            if (combatSystem.totalBlockSelected > 0) combatSystem.BlockDamage(-defenseValue);

            if (combatSystem.totalDodgeSelected > 0) combatSystem.DodgeDamage(-dodgeValue);
         
            useMenu.setCancelingBool(false);
        }
    }
}
