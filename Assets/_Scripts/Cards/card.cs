using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;
    public int manaCost;
    public int value;
    public string cardName;
    public string classification;
    public string cardDescription;
    public string imageFilePath;

    public Card(int cardID, int manaCost, string classification, string cardName, int value, string cardDescription, string imageFilePath)
    {
        this.cardID = cardID;
        this.manaCost = manaCost;
        this.classification = classification;
        this.cardName = cardName;
        this.value = value;
        this.cardDescription = cardDescription;
        this.imageFilePath = imageFilePath;
    }

}