using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToTheFront : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(waitASecond());  
    }
    IEnumerator waitASecond()
    {
        transform.SetAsLastSibling();
        yield return new WaitForSeconds(1);
        if (DeckGenerator.listSize == 0) gameObject.SetActive(false);
    }
}
