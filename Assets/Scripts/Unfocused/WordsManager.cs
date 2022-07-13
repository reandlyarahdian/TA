using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordsManager : MonoBehaviour
{
    public static WordsManager instance;
    public int points { get; private set; }
    public string words { get; private set; }

    [SerializeField] private WordsDataScriptable wordsScriptable;
    [SerializeField] private GameObject twitbanner;
    [SerializeField] private Transform viewBanner;
    [SerializeField] private WordsPlacer[] answerWordList;     
    [SerializeField] private WordsPlacer[] optionsWordList;    

    private string[] wordsArray = new string[12];
    private int[] pointArray = new int[12];

    private List<int> selectedWordsIndex;
    private int currentAnswerIndex = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        selectedWordsIndex = new List<int>();           
        SetWord();                                 
    }

    void SetWord()
    {               

        ResetWord();                                  

        selectedWordsIndex.Clear();                  
        Array.Clear(wordsArray, 0, wordsArray.Length);
        Array.Clear(pointArray, 0, pointArray.Length);

        for (int i = 0; i < wordsArray.Length; i++)
        {
            wordsArray[i] = wordsScriptable.data[UnityEngine.Random.Range(0, wordsScriptable.data.Count)].words;
            pointArray[i] = wordsScriptable.data[UnityEngine.Random.Range(0, wordsScriptable.data.Count)].point;
        }

        wordsArray = ShuffleList.ShuffleListItems<string>(wordsArray.ToList()).ToArray(); 
        for (int k = 0; k < optionsWordList.Length; k++)
        {
            optionsWordList[k].SetWord(wordsArray[k]);
            optionsWordList[k].SetPoint(pointArray[k]);
        }

    }

    public void ResetWord()
    {
        for (int i = 0; i < answerWordList.Length; i++)
        {
            answerWordList[i].gameObject.SetActive(true);
            answerWordList[i].SetWord("");
            answerWordList[i].SetPoint(0);
        }

        for (int i = answerWordList.Length; i < answerWordList.Length; i++)
        {
            answerWordList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < optionsWordList.Length; i++)
        {
            optionsWordList[i].gameObject.SetActive(true);
        }

        currentAnswerIndex = 0;
        points = 0;
    }

    public void SelectedOption(WordsPlacer value)
    {
        if (currentAnswerIndex < answerWordList.Length)
        {
            selectedWordsIndex.Add(value.transform.GetSiblingIndex());
            value.gameObject.SetActive(false);
            answerWordList[currentAnswerIndex].SetWord(value.wordValue);
            answerWordList[currentAnswerIndex].SetPoint(value.pointValue);
            points += answerWordList[currentAnswerIndex].pointValue;
            if (currentAnswerIndex == 0)
            {
                words = answerWordList[currentAnswerIndex].wordValue;
            }
            else
            {
                words = words.Insert(words.Length, " " + answerWordList[currentAnswerIndex].wordValue);
            }
            currentAnswerIndex++;
        }
        currentAnswerIndex = currentAnswerIndex >= answerWordList.Length ? answerWordList.Length : currentAnswerIndex;
    }

    public void ResetLastWord()
    {
        if (selectedWordsIndex.Count > 0)
        {
            int index = selectedWordsIndex[selectedWordsIndex.Count - 1];
            optionsWordList[index].gameObject.SetActive(true);
            selectedWordsIndex.RemoveAt(selectedWordsIndex.Count - 1);

            currentAnswerIndex--;

            points -= answerWordList[currentAnswerIndex].pointValue;
            words = words.Remove(words.Length - (answerWordList[currentAnswerIndex].wordValue.Length + 1));

            answerWordList[currentAnswerIndex].SetWord("");
            answerWordList[currentAnswerIndex].SetPoint(0);
        }
    }

    public void Completed()
    {
        GameObject game = Instantiate(twitbanner, viewBanner);
        game.GetComponent<Twt>().twt = words;
        game.GetComponent<Twt>().RT = points;
        game.GetComponent<Twt>().Like = points;
        game.GetComponent<Twt>().twxting();
        SetWord();
    }
}
