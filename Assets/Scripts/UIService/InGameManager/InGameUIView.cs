
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    private InGameUIController inGameUIController;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] RectTransform PickupContainerParent;
    [SerializeField] GameObject pauseMenuGB;
    [SerializeField] Button ResumeFromPauseMenuButton;
    [SerializeField] Button ExitToLobbyScreenButton;
    public void SetController(InGameUIController inGameUIController)
    {
        this.inGameUIController = inGameUIController;  
    }

    private void Start()
    {
        ResumeFromPauseMenuButton.onClick.AddListener(OnResumeFromPauseButtonClicked);
        ExitToLobbyScreenButton.onClick.AddListener(OnExitToLobbyScreenButtonClicked);
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
    }


    public GameObject GetPauseMenuGB() => pauseMenuGB;

    public TextMeshProUGUI GetScoreText() => scoreText;
}
