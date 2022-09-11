using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ============================================ Mostly finished Class ===============================================
/// </summary>
public class SpawnCard : MonoBehaviour
{
    public DeckSize deck;

    [SerializeField] private DeckGenerator deckGen;
    public GameObject card;
    private GameObject hand;
    private GameObject newCard;
    public List<GameObject> cards;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {

        //Example of the GameObject being found
        if (tag == "Player")
        {
            hand = GameObject.Find("Hand");
        }
        else if (tag == "Enemy")
        {
            hand = GameObject.Find("EnemyHand");
        }
    }
    public void buttonPress()
    {
        Destroy(newCard);
        newCard = Instantiate(card, spawnPoint.position, spawnPoint.rotation, hand.transform);
        for (int i = 4; i < 0; i--)
        {
            if (cards.Count < 5)
            {
                cards.Add(newCard);
            }
            
        }
        deck.deckSize -= 1;
    }
}