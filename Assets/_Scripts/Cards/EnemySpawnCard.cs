using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class EnemySpawnCard : MonoBehaviour
{
    public DeckSize deck;

    public GameObject card;
    private GameObject hand;
    public List<GameObject> handList = new List<GameObject>();
    [SerializeField] private Transform spawnPoint6;
    [SerializeField] private Transform spawnPoint7;
    [SerializeField] private Transform spawnPoint8;

    private void Awake()
    {
        //Example of the GameObject being found
        hand = GameObject.Find("EnemyHand");
    }
    public void buttonPress()
    {
        for (int i = 0; i < handList.Count; i++)
        {
            Destroy(handList[i]);
        }
        handList.Clear();
        handList.Add(Instantiate(card, spawnPoint6.position, spawnPoint6.rotation, hand.transform));
        handList.Add(Instantiate(card, spawnPoint7.position, spawnPoint7.rotation, hand.transform));
        handList.Add(Instantiate(card, spawnPoint8.position, spawnPoint8.rotation, hand.transform));
        deck.deckSize -= 3;
    }
}