using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    public AudioMixerGroup audioMixer, BGM;

    private UnityAction onEnd;
    private void Awake()
    {
        instance = this;
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.outputAudioMixerGroup = audioMixer;
            if (sound.name == "BGM")
                sound.source.outputAudioMixerGroup = BGM;
            sound.source.clip = sound.clip;
            sound.source.volume = sound.Volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public AudioManager OnEnd(UnityAction action)
    {
        onEnd = action;
        return this;
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) return;
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) return;
        sound.source.Stop();
    }

    public void ChainPlay(string music1, string music2)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == music1);
        if (sound == null) return;
        sound.source.Play();
        StartCoroutine(AfterPlayed(sound.source, () => {
            Sound sound2 = Array.Find(sounds, sound => sound.name == music2);
            sound2.source.Play();
        }));
    }

    public void ChainStop(string music1, string music2)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == music1);
        if (sound == null) return;
        sound.source.Stop();
        StartCoroutine(AfterPlayed(sound.source, () => {
            Sound sound2 = Array.Find(sounds, sound => sound.name == music2);
            sound2.source.Stop();
        }));
    }

    IEnumerator AfterPlayed(AudioSource audioSource, UnityAction action)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        action.Invoke();
    }

    public AudioSource source(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) return null;
        sound.source.Play();
        return sound.source;
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;
    [Range(0f,1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
}
