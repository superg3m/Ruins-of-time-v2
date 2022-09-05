using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Device;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject backOfCard;
    [SerializeField] private GameObject targetButton;
    [SerializeField] private GameObject useScreen;
    [SerializeField] private Image cardBorder;
    
    private void Update()
    {
        if (gameObject.layer == 11 && Input.GetKeyDown(KeyCode.F))
        {
            if (backOfCard.activeInHierarchy) backOfCard.SetActive(false);
            else
            {
                backOfCard.SetActive(true);
            }
        }
    }
    public void ActivateCard()
    {
        if (useScreen.activeInHierarchy)
        {
            useScreen.SetActive(false);
        }
        else
        {
            useScreen.SetActive(true);
            targetButton.transform.localScale = new Vector3(1.05f, 1.00f, 1f);
            card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - 15, card.transform.position.z);
            cardBorder.color = Color.black;
            targetButton.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.layer = 11;
        targetButton.transform.localScale = new Vector3(1.05f, 1.15f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + 15, card.transform.position.z);
        cardBorder.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.layer = 0;
        targetButton.transform.localScale = new Vector3(1.05f, 1.00f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - 15, card.transform.position.z);
        cardBorder.color = Color.black;
    }
}
