
using UnityEngine;

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

    //Data
    [SerializeField] PlayerView playerView;
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
    public PlayerService PlayerService { get { return playerService; } }
    public GroundService GroundService { get { return groundService; } }

    private void Init()
    {
        playerService = new PlayerService(playerView,playerDataSO);
        groundService=new GroundService(groundPrefab,pickupPrefab,groundOffsetZ,groundOffsetY,pickupCount,powerUpSpawningRate);
        Debug.Log("Hello");
    }


}
