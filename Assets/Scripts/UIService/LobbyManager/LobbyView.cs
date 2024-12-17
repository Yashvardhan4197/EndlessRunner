
using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] Transform changeMaterialCardParent;
    [SerializeField] Button changeMaterialPopUpOpenButton;
    [SerializeField] Button changeMaterialPopUpCloseButton;
    [SerializeField] Transform changeMaterialPopUp;
    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        changeMaterialPopUpCloseButton.onClick.AddListener(CloseChangeMaterialPopUp);
        changeMaterialPopUpOpenButton.onClick.AddListener(OpenChangeMaterialPopUp);
    }

    private void CloseChangeMaterialPopUp()
    {
        lobbyController.ToggleChangeMaterialPopUp(false);
    }

    private void OpenChangeMaterialPopUp()
    {
        lobbyController.ToggleChangeMaterialPopUp(true);
    }

    public void OnStartButtonClicked()
    {
        lobbyController.StartGame();
    }

    public void OnExitButtonClicked()
    {
        lobbyController.ExitGame();
    }

    public Transform GetChangeMaterialCardParent() => changeMaterialCardParent;

    public Transform GetChangeMaterialPopUp()=> changeMaterialPopUp;

}
