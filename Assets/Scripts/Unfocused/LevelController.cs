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

    int targetPoint = 50;

    private void Start()
    {
        instance = this;
        StartCoroutine(notifTimer());
        targetText.text = $"Target {targetPoint}";
    }

    IEnumerator notifTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            tabs[Random.Range(0, 1)].Notif(true);
            tabs[2].enabled = false;
            yield return new WaitForSeconds(5f);
            tabs[2].enabled = true;
            yield return null;
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
}
