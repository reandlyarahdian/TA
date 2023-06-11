using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioManager audioManager;
    [SerializeField] string[] songName;
    [SerializeField] Slider songSlider;

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
        if(volume < 1)
        {
            volume = .001f;
        }

        RefreshSlider(volume);
        audioMixer.SetFloat("Volume", Mathf.Log10(volume /100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(songSlider.value);
    }

    public  void RefreshSlider(float value)
    {
        songSlider.value = value;
    }
}
