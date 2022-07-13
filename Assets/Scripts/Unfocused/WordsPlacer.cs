using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordsPlacer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordText;

    [HideInInspector]
    public string wordValue;
    [HideInInspector]
    public int pointValue;

    public void SetWord(string value)
    {
        wordText.text = value + "";
        wordValue = value;
    }

    public void SetPoint(int value)
    {
        pointValue = value;
    }

    public void WordSelected()
    {
        WordsManager.instance.SelectedOption(this);
    }
}