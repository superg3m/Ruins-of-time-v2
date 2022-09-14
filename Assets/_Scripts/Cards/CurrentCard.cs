using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using Newtonsoft.Json.Linq;

/// <summary>
/// ============================================ Mostly finished Class ================================================
/// This Class need to have less public variables
/// This class need to use GameObject.Find(" ") to refenece the GameObjects
/// The switch statement need to be put into a differnt class called ChangeBannerColor line(55-69)
/// </summary>
public class CurrentCard : MonoBehaviour
{
    public Sprite cardImage;
    public Image image;
    public TMP_Text manaCostText;
    public TMP_Text nameText;
    public TMP_Text classificationText;
    public TMP_Text descriptionText;
    public Image bannerColor;

    [SerializeField] private Image cardBorder;

    public List<CardBaseObject> currentCard = new List<CardBaseObject>();

    public int currentID;

    public int id;
    public int manaCost;
    public string classification;
    public string cardName;
    public int attackValue;
    public int defenseValue;
    public int dodgeValue;
    public string status;
    public int statusQuanity;
    public string cardDescription;

    public bool isSelected;



    void Start()
    {
        if (transform.parent.tag == "Player")
        {
            currentID = Random.Range(0, DeckGenerator.playerCardList.Length - 1);
            currentCard.Add(DeckGenerator.playerCardList[0]);
        }
        else if (transform.parent.tag == "Enemy")
        {
            currentID = Random.Range(0, DeckGenerator.enemyCardList.Length - 1);
            currentCard.Add(DeckGenerator.enemyCardList[0]);
        }
    }

    public void setSelectionBool(bool boolean)
    {
        isSelected = boolean;
    }

    void Update()
    {
        if (transform.parent.tag == "Player")
        {
            currentID = System.Math.Clamp(currentID, 0, DeckGenerator.playerCardList.Length - 1);

            currentCard[0] = DeckGenerator.playerCardList[currentID];
            id = currentCard[0].cardID;

            manaCost = currentCard[0].manaCost;
            cardName = currentCard[0].cardName;
            classification = currentCard[0].classification;
            attackValue = currentCard[0].attackValue;
            defenseValue = currentCard[0].defenseValue;
            dodgeValue = currentCard[0].dodgeValue;
            status = currentCard[0].status;
            statusQuanity = currentCard[0].statusQuanity;
            cardDescription = currentCard[0].cardDescription;
            image.sprite = currentCard[0].cardImage;

            switch (classification)
            {
                case "Offensive":
                    bannerColor.color = Color.red;
                    break;
                case "Defensive":
                    bannerColor.color = Color.blue;
                    break;
                case "Alteration":
                    bannerColor.color = Color.magenta;
                    break;
                case "Status":
                    bannerColor.color = new Color(0, .5f, 0);
                    break;
            }

            manaCostText.text = "" + manaCost;
            nameText.text = "" + cardName;
            classificationText.text = "" + classification;
            descriptionText.text = "" + cardDescription;
        }

        else if (transform.parent.tag == "Enemy")
        {
            currentID = System.Math.Clamp(currentID, 0, DeckGenerator.enemyCardList.Length - 1);

            currentCard[0] = DeckGenerator.enemyCardList[currentID];
            id = currentCard[0].cardID;

            manaCost = currentCard[0].manaCost;
            cardName = currentCard[0].cardName;
            classification = currentCard[0].classification;
            attackValue = currentCard[0].attackValue;
            defenseValue = currentCard[0].defenseValue;
            dodgeValue = currentCard[0].dodgeValue;
            status = currentCard[0].status;
            statusQuanity = currentCard[0].statusQuanity;
            cardDescription = currentCard[0].cardDescription;
            image.sprite = currentCard[0].cardImage;

            switch (classification)
            {
                case "Offensive":
                    bannerColor.color = Color.red;
                    break;
                case "Defensive":
                    bannerColor.color = Color.blue;
                    break;
                case "Alteration":
                    bannerColor.color = Color.magenta;
                    break;
                case "Status":
                    bannerColor.color = new Color(0, .5f, 0);
                    break;
            }

            manaCostText.text = "" + manaCost;
            nameText.text = "" + cardName;
            classificationText.text = "" + classification;
            descriptionText.text = "" + cardDescription;
            if (isSelected)
            {
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z);
                cardBorder.color = Color.red;
            }
            else
            {
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 15, this.transform.position.z);
                cardBorder.color = Color.black;
            }
        }
    }
}
