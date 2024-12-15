using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private PlayerDataSO playerDataSO;
    private Rigidbody rb;
    private int currentLane;
    private float targetXPos;
    private bool doubleSpeedCheck;
    private bool gamePaused;
    public bool GamePaused { get { return gamePaused; } }
    public PlayerController(PlayerView playerView,PlayerDataSO playerDataSO)
    {
        this.playerView = playerView;
        this.playerDataSO = playerDataSO;
        playerView.SetController(this);
        rb=playerView.GetRigidbody();
        GameService.Instance.GameStartAction += OnGameStart;
        gamePaused = true;
    }

    public void OnGameStart()
    {
        playerView.gameObject.transform.position = playerDataSO.StartPosition.position;
        currentLane = 0;
        targetXPos=playerView.transform.position.x;
        doubleSpeedCheck = false;
        gamePaused = false;
    }
    
    public void Move()
    {
        if (!doubleSpeedCheck)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, playerDataSO.ForwardSpeed);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, playerDataSO.ForwardSpeed*2);
        }
        Vector3 newPos = new Vector3(targetXPos, rb.position.y, rb.position.z);
        rb.MovePosition(Vector3.Lerp(rb.position, newPos, playerDataSO.HorizontalSpeed * Time.deltaTime));
    }

    public void MoveLane(int lane)
    {
        currentLane = Math.Clamp(currentLane + lane, -1, 1);
        targetXPos = currentLane * playerDataSO.LaneDistance;
    }

    public void PerformJump()
    {
        rb.velocity += playerDataSO.JumpSpeed * Vector3.up;
    }

    public void OnPlayerDead()
    {
        Debug.Log("GameLost");
    }

    public void SpawnGround()
    {
        GameService.Instance.GroundService.SpawnGroundObject();
    }

    public void SetDoubleSpeedCheck(bool check) => doubleSpeedCheck = check;

    public void SetPauseStatus()
    {
        if (gamePaused)
        {
            SetPauseStatus(false);
        }
        else
        {
            SetPauseStatus(true);
        }
    }

    public void SetPauseStatus(bool pause)
    {
        gamePaused=pause;
    }

}

