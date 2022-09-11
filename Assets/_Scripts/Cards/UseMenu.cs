using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

/// <summary>
/// ============================================ Unfinished Class =====================================================
/// This Class need to link up to another class 
/// the other class needs to handle the cursor changing to a sniper crosshair when isUsingCard == true
/// the other class also needs to handle changing the cursor back when isUsingCard == false
/// </summary>
public class UseMenu : MonoBehaviour
{
    [SerializeField] private GameObject useScreen;
    [SerializeField] private GameObject flipButton;
    public GameObject cardToSort;
    public GameObject cardToRemove;
    public PlayerCombatSystem combatSystem;
    public Button button;
    public bool isUsingCard;
    public HealthSystem enemyHealth;
    public string currentStatus;
    List<string> statusList;
    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;

    private void Awake()
    {
        currentStatus = "";
        enemyHealth = GameObject.Find("EnemyHealthBar").GetComponent<HealthSystem>();
        combatSystem = GameObject.Find("CombatSystem").GetComponent<PlayerCombatSystem>();
    }
    private void Update()
    {

    }
    // These methods are used by the GameObejcts under the "UseSceen" GameObject

    // This method is used by the GameObject "UseButton" and is attached to the button componet
    public void usingButton()
    {
        button.interactable = false;
        isUsingCard = true;
        string description = cardToSort.GetComponent<CurrentCard>().descriptionText.text;
        string type = cardToSort.GetComponent<CurrentCard>().classificationText.text;
        int value = cardToSort.GetComponent<CurrentCard>().value;
        if (type == "Offensive")
        {
            combatSystem.GatherDamage(value);
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
            bool hasBurn = description.Contains("burn");
            bool hasHeal = description.Contains("heal");
            bool hasPoison = description.Contains("poison");
            bool hasBleeding = description.Contains("bleeding");
            bool hasVulnerable = description.Contains("vulnerable");
            if (hasBurn)
            {
                currentStatus = "burn";
                combatSystem.GatherStatuses(currentStatus);
                combatSystem.GatherDamage(value);
                enemyHealth.RegenerateHealth(-value);
            }
            if (hasHeal)
            {
                currentStatus = "heal";
                combatSystem.GatherStatuses(currentStatus);
            }
            if (hasPoison)
            {
                currentStatus = "poison";
                combatSystem.GatherStatuses(currentStatus);
                combatSystem.GatherDamage(value);
                enemyHealth.RegenerateHealth(-value);
            }
            if (hasBleeding)
            {
                currentStatus = "bleeding";
                combatSystem.GatherStatuses(currentStatus);
                combatSystem.GatherDamage(value);
                enemyHealth.RegenerateHealth(-value);

            }
            if (hasVulnerable)
            {
                currentStatus = "vulnerable";
                combatSystem.GatherStatuses(currentStatus);
            }
        }
    }

    // This method is used by the GameObject "CancelButton" and is attached to the button componet
    public void cancelButton()
    {
        button.interactable = true;
        isUsingCard = false;
        useScreen.transform.SetAsFirstSibling();
        flipButton.transform.SetAsLastSibling();
        string description = cardToRemove.GetComponent<CurrentCard>().descriptionText.text;
        string type = cardToRemove.GetComponent<CurrentCard>().classificationText.text;
        int value = cardToRemove.GetComponent<CurrentCard>().value;

        if (type == "Offensive" && combatSystem.totalDamageSelected > 0)
        {
            combatSystem.GatherDamage(-value);
        }
        else if (type == "Defensive" && combatSystem.totalBlockSelected > 0)
        {
            bool hasBlock = description.Contains("block");
            if (hasBlock)
            {
                combatSystem.BlockDamage(-value);
            }
        }
        else if (type == "Defensive" && combatSystem.totalDodgeSelected > 0)
        {
            bool hasDodge = description.Contains("dodge");
            if (hasDodge)
            {
                combatSystem.DodgeDamage(-value);
            }
        }
        else if (type == "Status")
        {
            bool hasBurn = description.Contains("burn");
            bool hasHeal = description.Contains("heal");
            bool hasPoison = description.Contains("poison");
            bool hasBleeding = description.Contains("bleeding");
            bool hasVulnerable = description.Contains("vulnerable");
            if (hasBurn)
            {
                currentStatus = "burn";
                combatSystem.RemoveStatus(currentStatus);

            }
            if (hasHeal)
            {
                currentStatus = "heal";
                combatSystem.RemoveStatus(currentStatus);
            }
            if (hasPoison)
            {
                currentStatus = "poison";
                combatSystem.RemoveStatus(currentStatus);

            }
            if (hasBleeding)
            {
                currentStatus = "bleeding";
                combatSystem.RemoveStatus(currentStatus);


            }
            if (hasVulnerable)
            {
                currentStatus = "vulnerable";
                combatSystem.RemoveStatus(currentStatus);
            }
            hasBleeding = false;
            hasBurn = false;
            hasHeal = false;
            hasPoison = false;
            hasVulnerable = false;
        }
    }
}
