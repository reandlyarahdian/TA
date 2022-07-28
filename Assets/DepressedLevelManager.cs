using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DepressedLevelManager : MonoBehaviour
{
    public static DepressedLevelManager instance;
    AudioManager AudioManager;

    void Start()
    {
        AudioManager = GetComponent<AudioManager>();
        AudioManager.Play("BGM");
    }

    public void Sound(string name)
    {
        StartCoroutine(AfterPlayed(AudioManager.source(name), SceneMenu));
    }

    IEnumerator AfterPlayed(AudioSource audioSource, UnityAction action)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        action.Invoke();
    }

    public void SceneMenu()
    {
        GameManager.Instance.Die();
        SceneManager.LoadScene("Menu");
    }
}
