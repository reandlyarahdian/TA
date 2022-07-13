﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTextManager : MonoBehaviour
{
    [SerializeField]
    private FileData _data;

    private Queue<string> _wordsQueue;
    private ITextAssetReader _textReader;
    private TypingManager typingManager;

    void Start()
    {
        if (_data != null)
        {
            _textReader = TextAssetReaderFactory.CreateReader(_data.ResourceType);
            _wordsQueue = _textReader.ReadFile(_data.WordsFile);
            typingManager = new TypingManager(GetNextWord());
            UIManager.instance.UpdateText(typingManager.GetCurrentWord());
            FindObjectOfType<InputHandler>().AssignOnInputListener(CheckPlayerInput);
        }
        else
        {
            throw new System.Exception("No data file assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetNextWord()
    {
        return _wordsQueue.Dequeue();
    }

    public void CheckPlayerInput(char c)
    {
        if (typingManager.CheckCharacter(c))
        {
            UIManager.instance.UpdateText(typingManager.GetCurrentWord());
            if (typingManager.CheckIfWordsFinished())
            {
                typingManager.SetAsNewWord(GetNextWord());
                UIManager.instance.UpdateText(typingManager.GetCurrentWord());
            }
        }
    }
}