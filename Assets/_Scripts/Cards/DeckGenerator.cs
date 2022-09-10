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
    public static CardBaseObject[] playerCardList;
    public static CardBaseObject[] enemyCardList;
    private CardBaseObject[] cache;

    public List<GameObject> playerDeck = new List<GameObject>();

    public  List<GameObject> enemyDeck = new List<GameObject>();

    [SerializeField] private List<GameObject> displayDeckSize = new List<GameObject>();

    public GameObject backCoverPrefab;
    public GameObject deckPos;
    public Transform buttonPos;
    public Transform spawnPoint;
    public Transform originalSpawnPoint;
    public static int listSize;
    public bool isCard;

    public static int playerDeckSize;
    public static int enemyDeckSize;

    public int playerCardCount;
    public int enemyCardCount;
    public float subtractXBy;
    

    private void Awake()
    {
        backCoverPrefab = (GameObject)Resources.Load("Prefabs/Card/CardBack", typeof(GameObject));
        originalSpawnPoint = GameObject.Find("OriginalSpawnPoint").transform;

        if (tag == "Player")
        {
            displayDeckSize = playerDeck;
            buttonPos = GameObject.Find("DeckButton").transform;
            spawnPoint = GameObject.Find("SpawnPoint").transform;
            playerCardList = Resources.LoadAll<CardBaseObject>("Scriptable Objects/Card Objects");
            deckPos = GameObject.Find("Deck");
            originalSpawnPoint = GameObject.Find("OriginalSpawnPoint").transform;
        }

        else if (tag == "Enemy")
        {
            displayDeckSize = enemyDeck;
            spawnPoint = GameObject.Find("EnemySpawnPoint").transform;
            buttonPos = GameObject.Find("EnemyDeckButton").transform;
            enemyCardList = Resources.LoadAll<CardBaseObject>("Scriptable Objects/EnemyCardObjects");
            deckPos = GameObject.Find("EnemyDeck");
            originalSpawnPoint = GameObject.Find("EnemyOriginalSpawnPoint").transform;
        }
    }
    private void Start()
    {
        if (!isCard)
        {
            if (tag == "Player")
            {
                originalSpawnPoint.transform.position = spawnPoint.transform.position;

                playerCardList = playerCardList.OrderBy(x => x.cardID).ToArray();
                cache = new CardBaseObject[playerCardList.Length];
                playerDeckSize = playerCardList.Length;
                for (int i = 0; i < playerCardList.Length; i++)
                {
                    cache[i] = playerCardList[i];
                }
            }
            else if (tag == "Enemy")
            {
                originalSpawnPoint.transform.position = spawnPoint.transform.position;

                enemyCardList = enemyCardList.OrderBy(x => x.cardID).ToArray();
                cache = new CardBaseObject[enemyCardList.Length];
                enemyDeckSize = enemyCardList.Length;
                for (int i = 0; i < enemyCardList.Length; i++)
                {
                    cache[i] = enemyCardList[i];
                }
            }
        }
    }
    private void Update()
    {
        if (!isCard)
        {
            if (tag == "Player")
            {
                if (playerCardCount != playerDeckSize)
                {
                    for (int i = 0; i < displayDeckSize.Count; i++)
                    {
                        Destroy(displayDeckSize[i]);
                    }
                    playerCardCount = 0;
                    subtractXBy = .5f;
                    displayDeckSize.Clear();
                    for (int i = 0; i < playerDeckSize; i++)
                    {
                        subtractXBy -= 0;
                        displayDeckSize.Add(Instantiate(backCoverPrefab, spawnPoint.position, spawnPoint.rotation, deckPos.transform));
                        spawnPoint.transform.position = new Vector3((spawnPoint.transform.position.x) - subtractXBy, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                        playerCardCount++;
                    }
                    buttonPos.transform.position = new Vector3(spawnPoint.transform.position.x, buttonPos.transform.position.y, buttonPos.transform.position.z);
                    spawnPoint.transform.position = originalSpawnPoint.transform.position;
                }
                listSize = displayDeckSize.Count;
            }
            else if (tag == "Enemy")
            {
                if (enemyCardCount != enemyDeckSize)
                {
                    for (int i = 0; i < displayDeckSize.Count; i++)
                    {
                        Destroy(displayDeckSize[i]);
                    }
                    enemyCardCount = 0;
                    subtractXBy = .5f;
                    displayDeckSize.Clear();
                    for (int i = 0; i < enemyDeckSize; i++)
                    {
                        subtractXBy -= 0;
                        displayDeckSize.Add(Instantiate(backCoverPrefab, spawnPoint.position, spawnPoint.rotation, deckPos.transform));
                        spawnPoint.transform.position = new Vector3((spawnPoint.transform.position.x) - subtractXBy, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                        enemyCardCount++;
                    }
                    buttonPos.transform.position = new Vector3(spawnPoint.transform.position.x, buttonPos.transform.position.y, buttonPos.transform.position.z);
                    spawnPoint.transform.position = originalSpawnPoint.transform.position;
                }
                listSize = displayDeckSize.Count;
            }
        }
    }
    public void shuffle()
    {
        for (int i = 0; i < playerCardList.Length; i++)
        {
            playerCardList[0] = cache[i];
            int randomIndex = Random.Range(i, playerDeckSize);
            cache[i] = cache[randomIndex];
            cache[randomIndex] = playerCardList[0];
        }
    }
}
