using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// ============================================ Mostly finished Class =====================================================
/// This Class need to have less public variables
/// This class need to use GameObject.Find(" ") to refenece the GameObjects
/// This class need to be broken into a shuffle class for the DisplayDeckSize list
/// </summary>
public class DeckGenerator : MonoBehaviour
{
    public static CardBaseObject[] cardList;
    private CardBaseObject[] cache;

    [SerializeField] private List<GameObject> displayDeckSize = new List<GameObject>();

    public GameObject backCoverPrefab;
    public GameObject deckPos;
    public Transform buttonPos;
    public Transform spawnPoint;
    public Transform originalSpawnPoint;


    public int cardCount;
    public float subtractXBy;
    public int deckSize;

    private void Awake()
    {
        cardList = Resources.LoadAll<CardBaseObject>("Scriptable Objects/Card Objects");
    }
    private void Start()
    {
        originalSpawnPoint.transform.position = spawnPoint.transform.position;
        
        cardList = cardList.OrderBy(x => x.cardID).ToArray();
        cache = new CardBaseObject[cardList.Length];
        deckSize = cardList.Length;
        for(int i = 0; i < cardList.Length; i++)
        {
            cache[i] = cardList[i];
        }
    }
    private void Update()
    {
        if(cardCount != deckSize)
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
