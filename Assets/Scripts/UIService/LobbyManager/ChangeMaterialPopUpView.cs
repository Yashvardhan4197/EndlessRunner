using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterialPopUpView : MonoBehaviour
{
    [SerializeField] Image materialImage;
    [SerializeField] TextMeshProUGUI materialName;
    [SerializeField] Button ChangeMaterialbutton;
    private int index;
    private LobbyController lobbyController;

    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

    private void Start()
    {
        ChangeMaterialbutton.onClick.AddListener(OnChangeMaterialButtonClicked);
    }

    private void OnChangeMaterialButtonClicked()
    {
        lobbyController.SetPlayerMaterial(index);
    }

    public Image GetMaterialImage() => materialImage;

    public TextMeshProUGUI GetMaterialName() => materialName;

    public void SetIndex(int index)=>this.index = index;
}
