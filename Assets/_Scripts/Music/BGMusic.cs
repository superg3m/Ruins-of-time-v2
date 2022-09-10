using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    public static GameObject[] musicInstance;
    // Start is called before the first frame update
    private void Awake()
    {
        musicInstance = GameObject.FindGameObjectsWithTag("MenuMusic");

        if (musicInstance.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Deck") Destroy(this.gameObject);
    }
}
