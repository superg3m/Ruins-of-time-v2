using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public GameObject card;
    public DrawCards drawCards;
    public Canvas canvas;
    private GameObject newCard;
    [SerializeField] private Transform spawnPoint;

    public void Start()
    {
        
        
    }
    public void buttonPress()
    {
        
        Destroy(newCard);
        newCard = Instantiate(card, spawnPoint.position, spawnPoint.rotation, canvas.transform);
    }
}
