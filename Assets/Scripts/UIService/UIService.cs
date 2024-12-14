public class UIService
{
    private LobbyController lobbyController;
    public UIService(LobbyView lobbyView)
    {
        lobbyController = new LobbyController(lobbyView);
    }
}