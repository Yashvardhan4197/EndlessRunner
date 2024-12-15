using UnityEngine;

public class InGameUIController
{
    private InGameUIView inGameUIView;
    private int score;
    private bool gamePaused;

    public InGameUIController(InGameUIView inGameUIView)
    {
        this.inGameUIView = inGameUIView;
        this.inGameUIView.SetController(this);
        GameService.Instance.GameStartAction += OnGameStart;
        inGameUIView.gameObject.SetActive(false);
    }

    public void OnGameStart()
    {
        score = 0;
        inGameUIView.GetScoreText().text=score.ToString();
        inGameUIView.GetPauseMenuGB().SetActive(false);
        inGameUIView.gameObject.SetActive(true);
        gamePaused = false;
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
    }

    public void TogglePauseMenu()
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

    public void ResumeGame()
    {
        ClosePauseScreen();
        gamePaused = false;
        GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(gamePaused);
    }

}