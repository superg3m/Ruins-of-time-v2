using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ============================================ Mostly finished Class ===============================================
/// </summary>
public class SpawnCard : MonoBehaviour
{
    [SerializeField] private DeckGenerator deckGen;
    public GameObject card;
    private GameObject hand;
    private GameObject newCard;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        //Example of the GameObject being found
        hand = GameObject.Find("Hand");
    }
    public void buttonPress()
    {
        Destroy(newCard);
        newCard = Instantiate(card, spawnPoint.position, spawnPoint.rotation, hand.transform);
        deckGen.deckSize -= 1;
    }
}