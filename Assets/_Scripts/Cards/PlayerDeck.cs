using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> cache = new List<Card>();

    public int x;
    public int deckSize;

    private void Start()
    {
        deckSize = 40;

        for (int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0, 4);
            deck[i] = CardDataBase.cardList[x];
        }
    }
    private void Update()
    {
        

    }

    public void shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            cache[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = cache[0];
        }
     }
}
