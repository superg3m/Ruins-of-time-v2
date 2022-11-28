using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ============================================ Unfinished Class =====================================================
/// This Class need to link up to another class 
/// the other class needs to handle the cursor changing to a sniper crosshair when isUsingCard == true
/// the other class also needs to handle changing the cursor back when isUsingCard == false
/// </summary>
public class UseMenu : MonoBehaviour
{
    [SerializeField] private GameObject useScreen;
    [SerializeField] private GameObject flipButton;
    public Button button;
    public bool isUsingCard;
    public bool isCanceling;

    private void Awake()
    {
        
    }
    private void Update()
    {
    
    }
    // These methods are used by the GameObejcts under the "UseSceen" GameObject

    // This method is used by the GameObject "UseButton" and is attached to the button componet
    public void usingButton()
    {
        button.interactable = false;
        gameObject.tag = "Selected";
        isUsingCard = true;
    }

    public void setUsingBool(bool boolean)
    {
       isUsingCard = boolean;
    }

    public void setCancelingBool(bool boolean)
    {
        isCanceling = boolean;
    }

    // This method is used by the GameObject "CancelButton" and is attached to the button componet
    public void cancelButton()
    {
        button.interactable = true;
        gameObject.tag = "Unselected";
        isCanceling = true;
        useScreen.transform.SetAsFirstSibling();
        flipButton.transform.SetAsLastSibling();
    }
}
