using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.LowLevel;

public class ActivateMenu : MonoBehaviour
{
    [SerializeField] private GameObject useScreen;
    [SerializeField] private GameObject flipButton;
    [SerializeField] private GameObject useButton;
    [SerializeField] private Image cardBorder;
    [SerializeField] private CombatSystem combatSystem;

    public static bool isShowingUseButton;

    private void Start()
    {
        useScreen.transform.SetAsFirstSibling();
        useButton.transform.SetAsFirstSibling();
    }
    public void ActivateCard()
    {
        if (isShowingUseButton)
        {
            useButton.transform.SetAsFirstSibling();
            useScreen.transform.SetAsFirstSibling();
            flipButton.transform.SetAsLastSibling();
        }
        else
        {
            useButton.transform.SetAsLastSibling();
            useScreen.transform.SetAsLastSibling();
            cardBorder.color = Color.black;
        }
    }
    public void SortCard(GameObject cardToSort)
    {
        string description = cardToSort.GetComponent<CardBaseObject>().cardDescription;
        string type = cardToSort.GetComponent<CardBaseObject>().classification;
        int value = cardToSort.GetComponent<CardBaseObject>().value;
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
                combatSystem.GatherStatuses("burn");
                combatSystem.GatherDamage(value);
                combatSystem.enemyHealth.RegenerateHealth(-value);
            }
            if (hasHeal)
            {
                combatSystem.GatherStatuses("heal");
            }
            if (hasPoison)
            {
                combatSystem.GatherStatuses("poison");
                combatSystem.GatherDamage(value);
                combatSystem.enemyHealth.RegenerateHealth(-value);
            }
            if (hasBleeding)
            {
                combatSystem.GatherStatuses("bleeding");
                combatSystem.GatherDamage(value);
                combatSystem.enemyHealth.RegenerateHealth(-value);

            }
            if (hasVulnerable)
            {
                combatSystem.GatherStatuses("vulnerable");
            }
        }

    }
    public void RemoveCard(GameObject cardToRemove)
    {
        string description = cardToRemove.GetComponent<CardBaseObject>().cardDescription;
        string type = cardToRemove.GetComponent<CardBaseObject>().classification;
        int value = cardToRemove.GetComponent<CardBaseObject>().value;
        if (type == "Offensive")
        {
            combatSystem.GatherDamage(-value);
        }
        else if (type == "Defensive")
        {
            bool hasBlock = description.Contains("block");
            if (hasBlock)
            {
                combatSystem.BlockDamage(-value);
            }
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
                combatSystem.GatherStatuses("burn");
                combatSystem.GatherDamage(-value);
                combatSystem.enemyHealth.RegenerateHealth(value);
            }
            if (hasHeal)
            {
                combatSystem.GatherStatuses("heal");
            }
            if (hasPoison)
            {
                combatSystem.GatherStatuses("poison");
                combatSystem.GatherDamage(-value);
                combatSystem.enemyHealth.RegenerateHealth(value);
            }
            if (hasBleeding)
            {
                combatSystem.GatherStatuses("bleeding");
                combatSystem.GatherDamage(-value);
                combatSystem.enemyHealth.RegenerateHealth(value);

            }
            if (hasVulnerable)
            {
                combatSystem.GatherStatuses("vulnerable");
            }
        }
    }
}
