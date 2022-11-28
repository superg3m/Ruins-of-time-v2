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

    public CardBaseObject[] generateDeck(string type)
    {
        if (type == "Player")
        {
            playerCardList = Resources.LoadAll<CardBaseObject>("Scriptable Objects/Card Objects");
            playerCardList = playerCardList.OrderBy(x => x.cardID).ToArray();
            return playerCardList;
        }
        else if (type == "Enemy")
        {
            enemyCardList = Resources.LoadAll<CardBaseObject>("Scriptable Objects/EnemyCardObjects");
            enemyCardList = enemyCardList.OrderBy(x => x.cardID).ToArray();
            return enemyCardList;
        }
        return null;
    }

    private void Start()
    {
        if (tag == "Player")
        {
            if (playerCardList != null)
            {
                cache = new CardBaseObject[playerCardList.Length];
                for (int i = 0; i < playerCardList.Length; i++)
                {
                    cache[i] = playerCardList[i];
                }
            }
        }
        else if (tag == "Enemy")
        {
            if (enemyCardList != null)
            {
                cache = new CardBaseObject[enemyCardList.Length];
                for (int i = 0; i < enemyCardList.Length; i++)
                {
                    cache[i] = enemyCardList[i];
                }
            }
        }
    }
    public void shuffle(List<CardBaseObject> cardList)
    {
        for (int i = 0; i < playerCardList.Length; i++)
        {
            playerCardList[0] = cache[i];
            int randomIndex = Random.Range(i, cardList.Count);
            cache[i] = cache[randomIndex];
            cache[randomIndex] = playerCardList[0];
        }
    }
}
