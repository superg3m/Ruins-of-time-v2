using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{

    private void Awake()
    {
        gameObject.tag = "Selected";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
