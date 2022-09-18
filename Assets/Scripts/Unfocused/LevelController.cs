using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public UnityEvent Sleepy, Socmed, Overtime;
    AudioManager AudioManager;

    float times = 1;

    int targetPoint = 50;

    private void Start()
    {
        AudioManager = GetComponent<AudioManager>();
        instance = this;
        StartCoroutine(notifTimer());
        targetText.text = $"Target {targetPoint}";
        Timer();
        AudioManager.Play("BGM");
    }

    private void Update()
    {
        words = textManager._wordsQueue;
        SleepyEnd();
        SocMedEnd();
    }

    IEnumerator notifTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            tabs[Random.Range(0, 3)].Notif(true);
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
        if(textManager.wordsComplited == 11)
        {
            StartCoroutine(trays());
            timer.SetRemainDuration(1020);
            
        }
    }

    IEnumerator trays()
    {
        while (times > 0)
        {
            tray.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            tray.gameObject.SetActive(false);
            Sleepy.Invoke();
            times -=Time.deltaTime;
        }
    }

    public void SocMedEnd()
    {
        if(words.Count == 0)
        {
            Socmed.Invoke();
        }
    }

    public void OvertimeEnd()
    {
        Overtime.Invoke();
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
        SceneManager.LoadScene("Menu");
    }
}
