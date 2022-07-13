using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "TextData", order = 1)]
public class scriptableText : ScriptableObject
{
    public List<DataText> text;
}

[System.Serializable]
public class DataText
{
    public string text;
    public int num;

    public DataText(string text, int num)
    {
        this.text = text;
        this.num = num;
    }
}