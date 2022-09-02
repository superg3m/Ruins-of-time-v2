using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject target;
    [SerializeField] private Image cardBorder;
    public void OnPointerEnter(PointerEventData eventData)
    {
        target.transform.localScale = new Vector3(1.05f, 1.15f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + 15, card.transform.position.z);
        cardBorder.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target.transform.localScale = new Vector3(1.05f, 1.00f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - 15, card.transform.position.z);
        cardBorder.color = Color.black;
    }
}
