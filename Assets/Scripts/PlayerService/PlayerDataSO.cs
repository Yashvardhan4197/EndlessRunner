﻿
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] int forwardSpeed;
    [SerializeField] int horizontalSpeed;
    [SerializeField] int laneDistance;
    [SerializeField] float jumpSpeed;
    [SerializeField] Transform startPosition;
    [SerializeField] Material playerMaterial;
    public int ForwardSpeed { get { return forwardSpeed; } }
    public int HorizontalSpeed { get { return horizontalSpeed; } }
    public int LaneDistance {  get { return laneDistance; } }
    public float JumpSpeed {  get { return jumpSpeed; } }
    public Transform StartPosition { get { return startPosition; } }

    public Material PlayerMaterial { get {  return playerMaterial; } }

    public void SetPlayerMaterial(Material playerMaterial)=>this.playerMaterial = playerMaterial;

}

