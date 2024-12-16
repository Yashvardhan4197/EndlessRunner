
using UnityEngine;
using UnityEngine.Events;

public class GameService : MonoBehaviour
{
    #region SINGLETON
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
    #endregion

    #region VIEWS
    [SerializeField] PlayerView playerView;
    [SerializeField] LobbyView lobbyView;
    [SerializeField] InGameUIView inGameUIView;
    [SerializeField] PickupUIView pickupUIPrefab;
    #endregion

    #region DATA
    [SerializeField] Transform startPosition;
    [SerializeField] PlayerDataSO playerDataSO;
    [SerializeField] GroundObjectView groundPrefab;
    [SerializeField] PickupView pickupPrefab;
    [SerializeField] float groundOffsetZ;
    [SerializeField] float groundOffsetY;
    [SerializeField] int pickupCount;
    [SerializeField] int powerUpSpawningRate;
    [SerializeField] PickupDataSO pickupDataSO;
    [SerializeField] Transform groundParent;
    [SerializeField] Transform pickupParent;
    [SerializeField] AudioSource bgAudioSource;
    [SerializeField] AudioSource sFXAudioSource;
    [SerializeField] AudioSource SpecialAudioSource;
    [SerializeField] SoundType[] soundTypes;
    #endregion

    #region SERVICES
    private PlayerService playerService;
    private GroundService groundService;
    private UIService uIService;
    private SoundService soundService;
    public PlayerService PlayerService { get { return playerService; } }
    public GroundService GroundService { get { return groundService; } }
    public UIService UIService { get { return uIService; } }
    public SoundService SoundService {  get { return soundService; } }
    #endregion

    # region ACTIONS
    public UnityAction GameStartAction;
    public UnityAction GameLostAction;
    #endregion

    private void Init()
    {
        playerService = new PlayerService(playerView,playerDataSO);
        groundService=new GroundService(groundPrefab,pickupPrefab,groundOffsetZ,groundOffsetY,pickupCount,powerUpSpawningRate,pickupDataSO,groundParent,pickupParent);
        uIService=new UIService(lobbyView,inGameUIView,pickupUIPrefab);
        soundService=new SoundService(bgAudioSource,sFXAudioSource,SpecialAudioSource,soundTypes);
        UIService.GetLobbyController().OpenLobby();
        soundService.PlayBackGroundAudio(Sound.BACKGROUND_MUSIC);
    }


}
