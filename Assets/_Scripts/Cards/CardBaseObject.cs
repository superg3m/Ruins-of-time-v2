using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "CardDataBase/Card Data")]
public class CardBaseObject : ScriptableObject
{
    public int cardID;
    public int manaCost;
    public string classification;
    public string cardName;
    public int value;
    public string cardDescription;
    public Sprite cardImage;
}