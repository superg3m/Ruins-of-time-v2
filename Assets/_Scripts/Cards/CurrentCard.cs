using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrentCard : MonoBehaviour
{
    public List<Card> currentCard = new List<Card>();

    public int currentID;

    public int id;
    public int manaCost;
    public string classification;
    public string cardName;
    public int value;
    public string cardDescription;
    public string imageFilePath;

    public Image image;
    public TMP_Text manaCostText;
    public TMP_Text nameText;
    public TMP_Text classificationText;
    public TMP_Text descriptionText;
    public Image bannerColor;

    private void Awake()
    {
        currentID = Random.Range(0, 4);
    }

    void Start()
    {
        currentCard[0] = CardDataBase.cardList[0];
    }

    void Update()
    {
        currentID = System.Math.Clamp(currentID, 0, CardDataBase.cardList.Length-1);

        

        currentCard[0] = CardDataBase.cardList[currentID];
        id = currentCard[0].cardID;

        manaCost = currentCard[0].manaCost;
        cardName = currentCard[0].cardName;
        classification = currentCard[0].classification;
        value = currentCard[0].value;
        cardDescription = currentCard[0].cardDescription;
        imageFilePath = currentCard[0].imageFilePath;

        image.sprite = Resources.Load<Sprite>(imageFilePath);

        if (classification != "Offensive") bannerColor.color = Color.blue;
        else
        {
            bannerColor.color = Color.red;
        }

        manaCostText.text = "" + manaCost;
        nameText.text = "" + cardName;
        classificationText.text = "" + classification;
        descriptionText.text = "" + cardDescription;
    }
}
