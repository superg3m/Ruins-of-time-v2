using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defult Object", menuName = "Inventory System/Items/Gear")]
public class GearObject : ItemObject
{
    public float attackBonus;
    public float defenseBonus;
    public void Awake()
    {
        itemType = ItemType.Gear;
    }
}
