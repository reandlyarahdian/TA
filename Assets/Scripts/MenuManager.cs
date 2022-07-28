using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioManager audioManager;
    [SerializeField] string[] songName;

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        if(audioManager != null)
        {
            audioManager.Play(songName[Random.Range(0, songName.Length)]);
        }
    }

    public void GameScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
