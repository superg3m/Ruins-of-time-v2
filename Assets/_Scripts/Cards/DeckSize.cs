using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class DeckSize : MonoBehaviour
{
    public DeckGenerator deckgen;

    public GameObject backCoverPrefab;
    public GameObject deckPos;
    public Transform buttonPos;
    public Transform spawnPoint;
    private Transform originalSpawnPoint;

    public float subtractXBy;

    public int deckSize;

    public int cardCount;

    public List<GameObject> displayDeckSize = new List<GameObject>();

    public List<CardBaseObject> cards = new List<CardBaseObject>();

    private CardBaseObject[] cardList;

    private void Awake()
    {
        cardCount = 0;
        if (tag == "Player")
        {
            cardList = deckgen.GenerateDeck("Player");
            buttonPos = GameObject.Find("DeckButton").transform;
            spawnPoint = GameObject.Find("SpawnPoint").transform;
            deckPos = GameObject.Find("Deck");
            originalSpawnPoint = GameObject.Find("OriginalSpawnPoint").transform;
        }
        else if (tag == "Enemy")
        {
            cardList = deckgen.GenerateDeck("Enemy");
            spawnPoint = GameObject.Find("EnemySpawnPoint").transform;
            buttonPos = GameObject.Find("DeckButton").transform;
            deckPos = GameObject.Find("EnemyDeck");
            originalSpawnPoint = GameObject.Find("EnemyOriginalSpawnPoint").transform;
        }
    }
    private void Start()
    {
        for (int i = 0; i < cardList.Length; i++)
        {
            cards.Add(cardList[i]);
        }
        deckSize = cardList.Length;
        originalSpawnPoint.transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (deckSize <= 0 && tag == "Enemy")
        {
            deckSize = cardList.Length;
        }
        if (deckSize != cardCount)
        {
            for (int i = 0; i < displayDeckSize.Count; i++)
            {
                Destroy(displayDeckSize[i]);
            }
            cardCount = 0;
            subtractXBy = .5f;
            displayDeckSize.Clear();
            for (int i = 0; i < deckSize; i++)
            {
                subtractXBy -= 0;
                displayDeckSize.Add(Instantiate(backCoverPrefab, spawnPoint.position, spawnPoint.rotation, deckPos.transform));
                spawnPoint.transform.position = new Vector3((spawnPoint.transform.position.x) - subtractXBy, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                cardCount++;
            }
            buttonPos.transform.position = new Vector3(spawnPoint.transform.position.x, buttonPos.transform.position.y, buttonPos.transform.position.z);
            spawnPoint.transform.position = originalSpawnPoint.transform.position;
        }
    }
}