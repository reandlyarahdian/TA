using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordsData", menuName = "WordsData", order = 1)]
    public class WordsDataScriptable : ScriptableObject
    {
        public List<WordsData> data;
    }

    [System.Serializable]
    public class WordsData
    {
        public string words;
        public int point;
    }