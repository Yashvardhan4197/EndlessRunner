
using UnityEngine;

public class PlayerService
{
    private PlayerController playerController;
    public PlayerService(PlayerView playerView,PlayerDataSO playerDataSO)
    {
        playerController = new PlayerController(playerView,playerDataSO);
    }

    public PlayerController GetPlayerController() => playerController;
}

