using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTesting : MonoBehaviour
{
    public static event Action<int> onHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) onHit?.Invoke(-6);
    }
    /*
     private void OnEnable()
    {
        EventTesting.onHit += printRand; 
    }

    public void printRand()
    {
        Debug.Log("Loud and clear!");
    } 
     
     */
}
