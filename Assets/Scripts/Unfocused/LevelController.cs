using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    [SerializeField] TabBTN[] tabs;
    [SerializeField] Text targetText;
    [SerializeField] Board board;
    [SerializeField] Piece piece;
    [SerializeField] Timer timer;
    [SerializeField] GameTextManager textManager;
    Queue<string> words;
    [SerializeField] Image tray;

    float times = 1;

    int targetPoint = 50;

    float seconds = 60;

    private void Start()
    {
        instance = this;
        StartCoroutine(notifTimer());
        targetText.text = $"Target {targetPoint}";
        Timer();
    }

    private void Update()
    {
        words = textManager._wordsQueue;
        SleepyEnd();
    }

    IEnumerator notifTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            tabs[Random.Range(0, 2)].Notif(true);
            tabs[2].enabled = false;
            yield return new WaitForSeconds(20f);
            tabs[2].enabled = true;
        }
    }

    public void PointsTarget()
    {
        if(board.point == targetPoint)
        {
            piece.Tetris = false;
            board.GameOver();
        }
    }

    public void PointsSet()
    {
        targetPoint += 20;
        targetText.text = $"Target {targetPoint}";
    }

    public void Timer()
    {
        timer.MaxDuration = 1021;
        timer.SetDuration(900).Begin();
        timer.OnEnd(OvertimeEnd);
    }

    public void SleepyEnd()
    {
        if(textManager.wordsComplited == 10)
        {
            Times();
            timer.SetRemainDuration(1020);
        }
    }

    public void Times()
    {
        if(times <= 0)
        {
            tray.gameObject.SetActive(false);
        }
        else
        {
            tray.gameObject.SetActive(true);
            times -=Time.deltaTime;
        }
    }

    public void SocMedEnd()
    {
        if(words.Count == 0)
        {
            Times();
            timer.SetRemainDuration(1020);
        }
    }

    public void OvertimeEnd()
    {
        Times();
    }
}
