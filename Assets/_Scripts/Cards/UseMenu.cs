using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool isUsingCard;

    // These methods are used by the GameObejcts under the "UseSceen" GameObject


    // This method is used by the GameObject "UseButton" and is attached to the button componet
    public void usingButton()
    {
       isUsingCard = true;
    }

    // This method is used by the GameObject "CancelButton" and is attached to the button componet
    public void cancelButton()
    {
       isUsingCard = false;
       useScreen.transform.SetAsFirstSibling();
       flipButton.transform.SetAsLastSibling();
    }
}
