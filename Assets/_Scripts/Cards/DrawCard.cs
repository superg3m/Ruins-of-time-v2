using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public GameObject card;
    public Canvas canvas;
    private GameObject newCard;
    [SerializeField] private Transform spawnPoint;

    public void Start()
    {
        newCard = Instantiate(card, spawnPoint.position, spawnPoint.rotation, canvas.transform);
    }
    public void drawCards()
    {
        
       
    }
}
