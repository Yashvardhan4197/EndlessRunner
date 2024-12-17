public class UIService
{
    private LobbyController lobbyController;
    private InGameUIController inGameUIController;

    public UIService(LobbyView lobbyView, InGameUIView inGameUIView,PickupUIView pickupUIPrefab,ChangeMaterialPopUpView changeMaterialPopUpPrefab,ChangeMaterialPopUpDataSO changeMaterialPopUpDataSO)
    {
        lobbyController = new LobbyController(lobbyView,changeMaterialPopUpPrefab,changeMaterialPopUpDataSO);
        inGameUIController = new InGameUIController(inGameUIView,pickupUIPrefab);
    }

    public LobbyController GetLobbyController() => lobbyController;

    public InGameUIController GetInGameUIController() => inGameUIController;
}