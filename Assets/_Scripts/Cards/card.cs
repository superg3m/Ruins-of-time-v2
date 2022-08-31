using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;
    public int manaCost;
    public int attackDamage;
    public int armorValue;
    public string cardName;
    public string cardDescription;

    public Card()
    {

    }
    public Card(int cardID, int manaCost, string cardName, int attackDamage, int armorValue, string cardDescription)
    {
        this.cardID = cardID;
        this.manaCost = manaCost;
        this.cardName = cardName;
        this.attackDamage = attackDamage;
        this.armorValue = armorValue;
        this.cardDescription = cardDescription;
    }


}