using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private PlayerController playerController;
    [SerializeField] Transform jumpRadiusPosition;
    [SerializeField] float jumpRadius;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Renderer playerMeshRenderer;
    private void Start()
    {
        playerController?.OnGameStart();
    }

    private void FixedUpdate()
    {
        if (playerController.GamePaused==false)
        {
            playerController.Move();
        }
        
    }

    private void Update()
    {
        if (playerController.GamePaused==false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerController.MoveLane(-1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerController.MoveLane(+1);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bool isGround = Physics.CheckSphere(jumpRadiusPosition.position, jumpRadius, groundLayerMask);
                if (isGround)
                {
                    playerController.PerformJump();
                }
            }
        }

    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public Rigidbody GetRigidbody()=>rb;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer==3)
        {
            playerController.SpawnGround();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            playerController.OnPlayerDead();
        }
    }

    public Renderer GetPlayerRenderer() => playerMeshRenderer;

}
