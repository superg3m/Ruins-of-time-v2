using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTransitions : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void goToOptionsMenu()
    {
        SceneManager.LoadScene("OptionMenu");
    }
    public void goBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
