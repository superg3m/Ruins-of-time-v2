using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckGenerator : MonoBehaviour
{
    public static CardBaseObject[] cardList;
    [SerializeField] private CardBaseObject[] cache;
    int maxID;
    public int deckSize;
    private void Start()
    {
        cardList = Resources.LoadAll<CardBaseObject>("Scriptable Objects/Card Objects");
        cardList = cardList.OrderBy(x => x.cardID).ToArray();
        cache = new CardBaseObject[cardList.Length];
        deckSize = cardList.Length;
        for(int i = 0; i < cardList.Length; i++)
        {
            cache[i] = cardList[i];
        }
    }
    public void shuffle()
    {
        for (int i = 0; i < cardList.Length; i++)
        {
            cardList[0] = cache[i];
            int randomIndex = Random.Range(i, deckSize);
            cache[i] = cache[randomIndex];
            cache[randomIndex] = cardList[0];
        }
    }
}
