using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// ============================================ Mostly finished Class ===============================================
/// Need to break up this class
/// The new Class needs to handle the method showUseButton
/// </summary>

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject backOfCard;
    [SerializeField] private GameObject useButton;
    [SerializeField] private Button flipButton;
    [SerializeField] private GameObject useScreen;
    [SerializeField] private Image cardBorder;

    private void Start()
    {
        flipButton.transform.SetAsLastSibling();
    }
    private void Update()
    {
        if (gameObject.layer == 11 && Input.GetKeyDown(KeyCode.F))
        {
            if (backOfCard.activeInHierarchy)
            {
                flipButton.enabled = true;
                backOfCard.SetActive(false);
            }
            else
            {
                flipButton.enabled = false;
                backOfCard.transform.SetAsLastSibling();
                flipButton.transform.SetAsLastSibling();
                backOfCard.SetActive(true);
            }
        } 
    }
    public void showUseButton()
    {
        useScreen.transform.SetAsLastSibling();
        flipButton.transform.SetAsFirstSibling();
        ActivateMenu.isShowingUseButton = true;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.layer = 11;
        flipButton.transform.localScale = new Vector3(1.05f, 1.15f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + 15, card.transform.position.z);
        cardBorder.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.layer = 0;
        flipButton.transform.localScale = new Vector3(1.05f, 1.00f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - 15, card.transform.position.z);
        cardBorder.color = Color.black;
    }
}
