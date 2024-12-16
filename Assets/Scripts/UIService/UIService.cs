public class UIService
{
    private LobbyController lobbyController;
    private InGameUIController inGameUIController;

    public UIService(LobbyView lobbyView, InGameUIView inGameUIView,PickupUIView pickupUIPrefab)
    {
        lobbyController = new LobbyController(lobbyView);
        inGameUIController = new InGameUIController(inGameUIView,pickupUIPrefab);
    }

    public LobbyController GetLobbyController() => lobbyController;

    public InGameUIController GetInGameUIController() => inGameUIController;
}