
using UnityEngine;

public class LobbyController
{
    private LobbyView lobbyView;
    private ChangeMaterialPopUpView changeMaterialCardPrefab;
    private ChangeMaterialPopUpDataSO changeMaterialPopUpDataSO;
    public LobbyController(LobbyView lobbyView, ChangeMaterialPopUpView changeMaterialCardPrefab,ChangeMaterialPopUpDataSO changeMaterialPopUpDataSO)
    {
        this.lobbyView = lobbyView;
        this.lobbyView.SetController(this);
        Time.timeScale = 0f;
        this.changeMaterialCardPrefab = changeMaterialCardPrefab;
        this.changeMaterialPopUpDataSO = changeMaterialPopUpDataSO;
        InstantiateChangeMaterialPopUpCards();
    }

    public void ExitGame()
    {
        GameService.Instance.SoundService.PlaySFX(Sound.BUTTON_CLICK);
        Application.Quit();
    }

    public void StartGame()
    {
        GameService.Instance.GameStartAction?.Invoke();
        GameService.Instance.SoundService.PlaySFX(Sound.BUTTON_CLICK);
        lobbyView.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenLobby()
    {
        lobbyView.gameObject.SetActive(true);
        ToggleChangeMaterialPopUp(false);
        Time.timeScale = 0f;
    }

    public void ToggleChangeMaterialPopUp(bool status)
    { 
        lobbyView.GetChangeMaterialPopUp().gameObject.SetActive(status);
        GameService.Instance.SoundService.PlaySFX(Sound.BUTTON_CLICK);
    }


    private void InstantiateChangeMaterialPopUpCards()
    {
        for(int i = 0;i<changeMaterialPopUpDataSO.ChangeMaterialDataCollection.Length;i++)
        {
            ChangeMaterialPopUpView newCard= Object.Instantiate(changeMaterialCardPrefab);
            newCard.gameObject.transform.SetParent(lobbyView.GetChangeMaterialCardParent(),false);
            newCard.GetMaterialImage().sprite = changeMaterialPopUpDataSO.ChangeMaterialDataCollection[i].image;
            newCard.GetMaterialName().text = changeMaterialPopUpDataSO.ChangeMaterialDataCollection[i].name;
            newCard.SetIndex(i);
            newCard.SetController(this);
        }
    }

    public void SetPlayerMaterial(int index)
    {
        GameService.Instance.SoundService.PlaySFX(Sound.CHANGE_MATERIAL);
        GameService.Instance.PlayerService.GetPlayerController().SetPlayerMaterial(changeMaterialPopUpDataSO.ChangeMaterialDataCollection[index].material);
    }

}