
using UnityEngine;
using UnityEngine.Events;

public class GameService : MonoBehaviour
{
    private static GameService instance;
    public static GameService Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //VIEWS
    [SerializeField] PlayerView playerView;
    [SerializeField] LobbyView lobbyView;
    [SerializeField] InGameUIView inGameUIView;

    //DATA
    [SerializeField] Transform startPosition;
    [SerializeField] PlayerDataSO playerDataSO;
    [SerializeField] GroundObjectView groundPrefab;
    [SerializeField] PickupView pickupPrefab;
    [SerializeField] float groundOffsetZ;
    [SerializeField] float groundOffsetY;
    [SerializeField] int pickupCount;
    [SerializeField] int powerUpSpawningRate;

    //Services
    private PlayerService playerService;
    private GroundService groundService;
    private UIService uIService;
    public PlayerService PlayerService { get { return playerService; } }
    public GroundService GroundService { get { return groundService; } }
    public UIService UIService { get { return uIService; } }

    //ACTIONS
    public UnityAction GameStartAction;

    private void Init()
    {
        playerService = new PlayerService(playerView,playerDataSO);
        groundService=new GroundService(groundPrefab,pickupPrefab,groundOffsetZ,groundOffsetY,pickupCount,powerUpSpawningRate);
        uIService=new UIService(lobbyView,inGameUIView);
        UIService.GetLobbyController().OpenLobby();
    }


}
