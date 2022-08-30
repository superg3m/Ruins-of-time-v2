using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas Pause_UI;
    public bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("WORKING");
            if (gameIsPaused)
            {
                Resume();
            }
            else if (!gameIsPaused)
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        Pause_UI.GetComponent<Canvas>().enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        Pause_UI.GetComponent<Canvas>().enabled = true;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

}
