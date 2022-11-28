using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMusic : MonoBehaviour
{
    public AudioClip StartClip;
    public AudioClip LoopClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playMusic());
    }
    IEnumerator playMusic()
    {
        GetComponent<AudioSource>().clip = StartClip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(StartClip.length);
        GetComponent<AudioSource>().clip = LoopClip;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;

    }
    private void Update()
    {
        //if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "MainMenu") Destroy(this.gameObject);
    }
}
