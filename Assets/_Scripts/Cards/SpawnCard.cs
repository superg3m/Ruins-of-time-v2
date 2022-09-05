using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnCard : MonoBehaviour
{
    [SerializeField] private DeckGenerator deckGen;
    public GameObject card;
    public GameObject hand;
    private GameObject newCard;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
    }
    public void buttonPress()
    {
        Destroy(newCard);
        newCard = Instantiate(card, spawnPoint.position, spawnPoint.rotation, hand.transform);
        deckGen.deckSize -= 1;
    }
}
