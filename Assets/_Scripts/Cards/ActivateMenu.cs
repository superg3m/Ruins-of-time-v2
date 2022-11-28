using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.LowLevel;

public class ActivateMenu : MonoBehaviour
{
    [SerializeField] private GameObject useScreen;
    [SerializeField] private GameObject flipButton;
    [SerializeField] private GameObject useButton;
    [SerializeField] private Image cardBorder;

    public static bool isShowingUseButton;

    private void Start()
    {
        useScreen.transform.SetAsFirstSibling();
        useButton.transform.SetAsFirstSibling();
    }
    public void ActivateCard()
    {
        
        if (isShowingUseButton)
        {
            useButton.transform.SetAsFirstSibling();
            useScreen.transform.SetAsFirstSibling();
            flipButton.transform.SetAsLastSibling();
        }
        else
        {
            useButton.transform.SetAsLastSibling();
            useScreen.transform.SetAsLastSibling();
            cardBorder.color = Color.black;
        }
    }

    private void OnEnable()
    {
        //EventTesting.onHit += printRand; 
    }

    public void printRand()
    {
        Debug.Log("Loud and clear!");
    }

}
