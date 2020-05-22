using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int scoreP1, scoreP2, scaleP1, scaleP2, touchCountP1, touchCountP2;
    private UIController UIController;
    private delegate void PlayerScale();
    private event PlayerScale addScale, reduceScale;

    void Start()
    {
        UIController = FindObjectOfType<UIController>();
    }

    public void AddScoreP1(int value)
    {
        scoreP1 += value;
        UIController.ShowP1Score();
        CheckScoreP1();
    }

    public void AddScoreP2(int value)
    {
        scoreP2 += value;
        UIController.ShowP2Score();
        CheckScoreP2();
    }

    public int GetScoreP1()
    {
        return scoreP1;
    }

    public int GetScoreP2()
    {
        return scoreP2;
    }

    private void CheckScoreP1()
    {
        if (scoreP1 == 10)
        {
            //Debug.Log("Player 1 Win");
            UIController.P1Win();
            Time.timeScale = 0;
        }
    }

    private void CheckScoreP2()
    {
        if (scoreP2 == 10)
        {
            //Debug.Log("Player 2 Win");
            UIController.P2Win();
            Time.timeScale = 0;
        }
    }

    public void TouchCountP1(int touch)
    {
        touchCountP1 += touch;
        AddScaleP1();
    }

    public void TouchCountP2(int touch)
    {
        touchCountP2 += touch;
        AddScaleP2();
    }

    public int GetScaleP1()
    {
        return scaleP1;
    }

    public int GetScaleP2()
    {
        return scaleP2;
    }

    public void AddScaleP1()
    {
        if (touchCountP1 % 3 == 0)
        {
            scaleP1 += 1;
            addScale += ShowP1Scale;
            addScale();
            addScale -= ShowP1Scale;
        }
    }

    public void AddScaleP2()
    {
        if (touchCountP2 % 3 ==  0)
        {
            scaleP2 += 1;
            addScale += ShowP2Scale;
            addScale();
            addScale -= ShowP2Scale;
        }
    }

    public void ReduceScaleP1(int value)
    {
        scaleP1 -= value;
        reduceScale += ShowP1Scale;
        reduceScale();
        reduceScale -= ShowP1Scale;
    }

    public void ReduceScaleP2(int value)
    {
        scaleP2 -= value;
        reduceScale += ShowP2Scale;
        reduceScale();
        reduceScale -= ShowP2Scale;
    }

    private void ShowP1Scale()
    {
        UIController.ShowP1Scale();
    }

    private void ShowP2Scale()
    {
        UIController.ShowP2Scale();
    }
}
