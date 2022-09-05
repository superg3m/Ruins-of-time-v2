using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class UseCard : MonoBehaviour
{
    [SerializeField] private GameObject useScreen;
    [SerializeField] private GameObject targetButton;

    

    public bool isUsingCard;

    public void useButton()
    {
        isUsingCard = true;
    }

    public void cancelButton()
    {
        isUsingCard = false;
        useScreen.SetActive(false);
        targetButton.SetActive(true);
    }
}
