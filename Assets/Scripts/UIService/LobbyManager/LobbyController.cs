
using UnityEngine;

public class LobbyController
{
    private LobbyView lobbyView;

    public LobbyController(LobbyView lobbyView)
    {
        this.lobbyView = lobbyView;
        this.lobbyView.SetController(this);
        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameService.Instance.GameStartAction?.Invoke();
        lobbyView.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenLobby()
    {
        lobbyView.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}