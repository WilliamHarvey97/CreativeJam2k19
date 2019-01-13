using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    void Start()
    {
        this.audioSource= GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        StartCoroutine(wait5Seconds());
    }

    IEnumerator wait5Seconds() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GreetingScreen", LoadSceneMode.Single);
    }
}
