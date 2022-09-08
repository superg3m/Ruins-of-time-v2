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
        // Checks if the gameobject the script is attached too is on the 11th layer and if the key being pressed is F
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

    // This will need to be seperated into another class
    // This method forces the gameobjects into a certain order on the hierarchy
    public void showUseButton()
    {
        useScreen.transform.SetAsLastSibling();
        flipButton.transform.SetAsFirstSibling();
        ActivateMenu.isShowingUseButton = true;
    }

    // This unity method calculates when your cursor is over the gameobject and changes the layer of it
    // It also increases the y-value of the card and changes the color to red
    // This gives off the illusion that the card is being selected
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.layer = 11;
        flipButton.transform.localScale = new Vector3(1.05f, 1.15f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + 15, card.transform.position.z);
        cardBorder.color = Color.red;
    }

    // This unity method calculates when your cursor is off the gameobject and reverts all the changes that happened
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.layer = 0;
        flipButton.transform.localScale = new Vector3(1.05f, 1.00f, 1f);
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - 15, card.transform.position.z);
        cardBorder.color = Color.black;
    }
}
