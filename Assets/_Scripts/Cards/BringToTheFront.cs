using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BringToTheFront : MonoBehaviour
{
    public DeckGenerator deckGen;
    void Update()
    {
        StartCoroutine(waitASecond());  
    }
    IEnumerator waitASecond()
    {
        if (tag == "Player")
        {
            transform.SetAsLastSibling();
            yield return new WaitForSeconds(1);
            if (DeckGenerator.playerDeckSize <= 0) gameObject.SetActive(false);
        }
        else if (tag == "Enemy")
        {
            transform.SetAsLastSibling();
            yield return new WaitForSeconds(1);
            if (DeckGenerator.enemyDeckSize <= 0) gameObject.SetActive(false);
        }
    }
}
