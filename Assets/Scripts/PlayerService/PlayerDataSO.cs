
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] int forwardSpeed;
    [SerializeField] int horizontalSpeed;
    [SerializeField] int laneDistance;
    [SerializeField] Transform startPosition;
    public int ForwardSpeed { get { return forwardSpeed; } }
    public int HorizontalSpeed { get { return horizontalSpeed; } }
    public int LaneDistance {  get { return laneDistance; } }
    public Transform StartPosition { get { return startPosition; } }

}

