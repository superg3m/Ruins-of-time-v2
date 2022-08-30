using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDialog : MonoBehaviour
{
    [SerializeField] private GameObject exitDialog;

    private void Start()
    {
        exitDialog.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitDialog.SetActive(true);
        }
    }
    public void exitGame()
    {
        exitDialog.SetActive(true);
    }
    public void exitGame_yes()
    {
        Application.Quit();
    }

    public void exitGame_no()
    {
        exitDialog.SetActive(false);
    }
}
