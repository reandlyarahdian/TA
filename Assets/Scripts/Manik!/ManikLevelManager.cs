using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

public class ManikLevelManager : MonoBehaviour
{
    public NamePrice[] namePrices;
    public static ManikLevelManager instance;
    public List<NamePrice> pricePrices = new List<NamePrice>();
    public UnityEvent Money, NoMoney, TimeUp;
    AudioManager AudioManager;

    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI uGUI;

    private void Start()
    {
        instance = this;
        pricePrices = PopulatePrices(namePrices).ToList();
        timer.SetDuration(120).BeginBack();
        timer.OnEnd(timeUp);
        AudioManager = FindObjectOfType<AudioManager>();
        AudioManager.Play("BGM");
    }

    private void Update()
    {
        ShowPrices();
    }

    void timeUp()
    {
        TimeUp.Invoke();
    }

    private NamePrice[] PopulatePrices(NamePrice[] namePrices)
    {
        NamePrice[] temporaryList = new NamePrice[20];
        for(int i = 0; i < pricePrices.Count; i++)
        {
            NamePrice temporaryWord = namePrices[0];
            int randomIndex = Random.Range(i, namePrices.Length);
            temporaryList[i] = namePrices[randomIndex];
            temporaryList[randomIndex] = temporaryWord;
        }
        temporaryList = temporaryList.OrderBy(x => x.Name).ToArray();
        return temporaryList;
    }

    private void ShowPrices()
    {
        string prices = "Harus dibeli \n";
        var groups = pricePrices.GroupBy(v => v.Name);
        foreach(var group in groups)
            prices = prices.Insert(prices.Length, $"{group.Key} {group.Count()} \n");
        
        if (groups == null)
            prices = "";
        uGUI.text = prices;
    }

    public void Compare(NamePrice price)
    {
        foreach(var pair in pricePrices)
        {
            if (pair.Name==price.Name)
            {
                pricePrices.Remove(pair);
            }
        }
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

    private void SceneMenu()
    {
        SceneManager.LoadScene("4");
    }
}
