using System;
using UnityEngine;

public class InGameUIController
{
    private InGameUIView inGameUIView;
    private int score;
    private bool gamePaused;
    private bool gameLostStatus;

    public InGameUIController(InGameUIView inGameUIView)
    {
        this.inGameUIView = inGameUIView;
        this.inGameUIView.SetController(this);
        GameService.Instance.GameStartAction += OnGameStart;
        GameService.Instance.GameLostAction += GameLost;
        inGameUIView.gameObject.SetActive(false);
    }

    public void OnGameStart()
    {
        score = 0;
        inGameUIView.GetScoreText().text=score.ToString();
        inGameUIView.GetPauseMenuGB().SetActive(false);
        inGameUIView.gameObject.SetActive(true);
        inGameUIView.GetLostMenuGB().SetActive(false);
        gamePaused = false;
        gameLostStatus = false;
    }

    public void IncrementScore()
    {
        score++;
        inGameUIView.GetScoreText().text = score.ToString();
    }

    public void OpenPauseScreen()
    {
        inGameUIView.GetPauseMenuGB().SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseScreen()
    {
        GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(false);
        inGameUIView.GetPauseMenuGB().SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToLobby()
    {
        GameService.Instance.UIService.GetLobbyController().OpenLobby();
        inGameUIView.gameObject.SetActive(false);
        inGameUIView.GetPauseMenuGB().SetActive(false);
        inGameUIView.GetLostMenuGB().SetActive(false);
    }

    public void TogglePauseMenu()
    {
        if (!gameLostStatus)
        {
            if (gamePaused)
            {
                gamePaused = false;
                ClosePauseScreen();
            }
            else
            {
                gamePaused = true;
                OpenPauseScreen();
            }
            GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(gamePaused);
        }
    }

    public void ResumeGame()
    {
        ClosePauseScreen();
        gamePaused = false;
        GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(gamePaused);
    }

    public void RestartGame()
    {
        GameService.Instance.GameStartAction?.Invoke();
        Time.timeScale = 1f;
    }

    public void GameLost()
    {
        inGameUIView.GetLostMenuGB().SetActive(true);
        inGameUIView.GetPauseMenuGB() .SetActive(false);
        Time.timeScale = 0f;
        gameLostStatus = true;
    }
}