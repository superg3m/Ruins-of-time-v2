using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public HealthSystem playerHealth;
    public DamageSystem damageSystem;
    List<string> statusList;
    public int totalDamageSelected;
    public int totalBlockSelected;
    public int totalDodgeSelected;


    public void BlockDamage(int damageToBlock)
    {

    }
    public void DodgeDamage(int damageToDodge)
    {

    }
    public void GatherDamage(int damageToAdd)
    {
        totalDamageSelected += damageToAdd;
    }
    public void GatherStatuses(string statusToAdd)
    {
        
    }
    
}
