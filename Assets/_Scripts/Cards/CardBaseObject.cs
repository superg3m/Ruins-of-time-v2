using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ============================================ Finished Class ================================================
/// This Class need to have less public variables
/// This class need to use GameObject.Find(" ") to refenece the GameObjects
/// The switch statement need to be put into a differnt class called ChangeBannerColor line(55-69)
/// </summary>

// Allows the developer to create this scriptable object in the unity project files
[CreateAssetMenu(fileName = "CardData", menuName = "CardDataBase/Card Data")]
public class CardBaseObject : ScriptableObject
{
    public int cardID;
    public int manaCost;
    public string classification;
    public string cardName;
    public int attackValue;
    public int defenseValue;
    public int dodgeValue;
    public string status;
    public int statusQuanity;
    public string cardDescription;
    public Sprite cardImage;
}