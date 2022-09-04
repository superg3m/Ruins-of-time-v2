using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public GameObject card;
    public GameObject hand;
    private GameObject newCard;
    [SerializeField] private Transform spawnPoint;

    public void buttonPress()
    {
        
        Destroy(newCard);
        newCard = Instantiate(card, spawnPoint.position, spawnPoint.rotation, hand.transform);
    }
}
