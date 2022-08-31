using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, 5, "The Lord", 3, 0, "The King of Men")); // Card ID, Mana Cost, Card Name, Attack Damage, Armor Value, Card Description
        cardList.Add(new Card(1, 2, "Strike", 2, 0, "Strike them at thier hearts"));
        cardList.Add(new Card(2, 2, "Attack", 1, 0, "Slash at your foes"));
        cardList.Add(new Card(3, 8, "Defend", 0, 5, "Guard"));
    }
}
