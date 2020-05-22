using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI player1score, player2score, player1Scale, player2Scale, winnerText;
    [SerializeField]
    private GameObject pausePanel, winPanel;
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void ShowP1Score()
    {
        string score = gm.GetScoreP1().ToString();
        player1score.text = score; 
    }

    public void ShowP2Score()
    {
        string score = gm.GetScoreP2().ToString();
        player2score.text = score;
    }

    public void ShowP1Scale()
    {
        string scale = gm.GetScaleP1().ToString();
        player1Scale.text = scale;
    }

    public void ShowP2Scale()
    {
        string scale = gm.GetScaleP2().ToString();
        player2Scale.text = scale;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Gameplay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
    }

    public void P1Win()
    {
        winPanel.SetActive(true);
        string winner = "PLAYER 1 WIN";
        Debug.Log(winner);
        winnerText.text = winner;
    }

    public void P2Win()
    {
        winPanel.SetActive(true);
        string winner = "PLAYER 2 WIN";
        Debug.Log(winner);
        winnerText.text = winner;
    }
}
