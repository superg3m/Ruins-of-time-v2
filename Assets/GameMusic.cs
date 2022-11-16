using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioClip LoopClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playMusic());
    }
    IEnumerator playMusic()
    {
        GetComponent<AudioSource>().clip = LoopClip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(LoopClip.length);
        GetComponent<AudioSource>().loop = true;

    }
    private void Update()
    {
        //if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "MainMenu") Destroy(this.gameObject);
    }
}
