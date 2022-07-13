using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Twt : MonoBehaviour
{
    public Text twtText, likeText, rtText;
    public string twt;
    public int RT, Like;

    public void twxting()
    {
        twtText.text = twt;
        rtText.text = (RT/2).ToString();
        likeText.text = Like.ToString();
    }
}
