using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackCover : MonoBehaviour
{
    [SerializeField] private GameObject backOfCard;

    public void flip()
    {
        if(backOfCard.activeInHierarchy) backOfCard.SetActive(false);
        else
        {
            backOfCard.SetActive(true);
        }
    }
}
