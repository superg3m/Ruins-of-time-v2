using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BringToTheFront : MonoBehaviour
{
    public DeckSize deck;
    void Update()
    {
        StartCoroutine(waitASecond());  
    }
    IEnumerator waitASecond()
    {
        transform.SetAsLastSibling();
        yield return new WaitForSeconds(3);
        if (deck.deckSize <= 0) gameObject.SetActive(false);
    }
}
