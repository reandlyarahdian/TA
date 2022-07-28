using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject Transcript, Key, Object;
    public AudioManager AudioManager;

    void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        if (AudioManager != null)
        {
            StartCoroutine(AfterPlayed(AudioManager.source("Opening"), OnEnd));
        }
    }

    private void OnEnd()
    {
        Transcript.SetActive(false);
        Key.SetActive(true);
        Object.SetActive(false);
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator AfterPlayed(AudioSource audioSource, UnityAction action)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        action.Invoke();
    }
}
