using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static Card[] cardList = new Card[4];

    private void Awake()
    {
        // ==================== OFFENSIVE ====================
        cardList[0] = new Card(0, 5, "Offensive", "Cleave", 3, "Deal 3 <color=orange>damage</color> and <color=green>heal</color> for 4 life", "Cainos/Pixel Art Icon Pack - RPG/Texture/Weapon & Tool/Axe"); // Card ID, Mana Cost, Card Name, Attack Damage, Card Description, imageFilePath
        cardList[1] = new Card(1, 7, "Offensive", "Stab", 2, "Deal 2 <color=red>damage</color>", "Cainos/Pixel Art Icon Pack - RPG/Texture/Weapon & Tool/Knife");
        cardList[2] = new Card(2, 2, "Offensive", "Slash", 5, "Apply 5 <color=purple>poison</color>", "Cainos/Pixel Art Icon Pack - RPG/Texture/Weapon & Tool/Iron Sword");


        // ==================== DEFENSIVE ====================
        cardList[3] = new Card(3, 8, "Defensive", "Defend", 4, "Applies 4 <color=blue>block</color>", "Cainos/Pixel Art Icon Pack - RPG/Texture/Weapon & Tool/Iron Shield"); // Card ID, Mana Cost, Classification, Card Name, Armor Value, Card Description, imageFilePath
    }
}
