
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    private InGameUIController inGameUIController;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseMenuGB;
    [SerializeField] Button ResumeFromPauseMenuButton;
    [SerializeField] Button ExitToLobbyScreenButton;

    [SerializeField] GameObject lostGameMenuGB;
    [SerializeField] Button RestartFromLostMenuButton;
    [SerializeField] Button ExitToLobbyScreenButtonLostMenu;

    [SerializeField] RectTransform pickupBarsParent;
    public void SetController(InGameUIController inGameUIController)
    {
        this.inGameUIController = inGameUIController;  
    }

    private void Start()
    {
        ResumeFromPauseMenuButton.onClick.AddListener(OnResumeFromPauseButtonClicked);
        ExitToLobbyScreenButton.onClick.AddListener(OnExitToLobbyScreenButtonClicked);

        RestartFromLostMenuButton.onClick.AddListener(RestartGame);
        ExitToLobbyScreenButtonLostMenu.onClick.AddListener(OnExitToLobbyScreenButtonClicked);
    }

    private void RestartGame()
    {
        inGameUIController.RestartGame();
    }

    private void OnResumeFromPauseButtonClicked()
    {
        inGameUIController.ResumeGame();
    }

    private void OnExitToLobbyScreenButtonClicked()
    {
        inGameUIController.ExitToLobby();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            inGameUIController.TogglePauseMenu();
        }
        inGameUIController?.Update();
    }


    public GameObject GetPauseMenuGB() => pauseMenuGB;

    public GameObject GetLostMenuGB() => lostGameMenuGB;

    public TextMeshProUGUI GetScoreText() => scoreText;

    public RectTransform GetPickupBarParent() => pickupBarsParent;
}
