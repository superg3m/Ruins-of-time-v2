using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ============================================ Mostly finished Class ===============================================
/// </summary>
public class SpawnCard : MonoBehaviour
{
    public DeckSize deck;

    public GameObject card;
    private GameObject hand;
    public  HealthSystem healthSystem;

    public List<GameObject> handList = new List<GameObject>();
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private Transform spawnPoint4;
    [SerializeField] private Transform spawnPoint5;

    private void Awake()
    {
        //Example of the GameObject being found
        hand = GameObject.Find("Hand");
        healthSystem = GameObject.Find("PlayerHealthBar").GetComponent<HealthSystem>();
    }
    public void buttonPress()
    {
        healthSystem.clearData();

        for (int i = 0; i < handList.Count; i++)
        {
            Destroy(handList[i]);
        }
        handList.Clear();
        handList.Add(Instantiate(card, spawnPoint1.position, spawnPoint1.rotation, hand.transform));
        handList.Add(Instantiate(card, spawnPoint2.position, spawnPoint2.rotation, hand.transform));
        handList.Add(Instantiate(card, spawnPoint3.position, spawnPoint3.rotation, hand.transform));
        handList.Add(Instantiate(card, spawnPoint4.position, spawnPoint4.rotation, hand.transform));
        handList.Add(Instantiate(card, spawnPoint5.position, spawnPoint5.rotation, hand.transform));
        deck.deckSize -= 5;
    }
}