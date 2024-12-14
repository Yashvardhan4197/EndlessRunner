using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private PlayerController playerController;
    [SerializeField] Transform jumpRadiusPosition;
    [SerializeField] float jumpRadius;
    [SerializeField] LayerMask groundLayerMask;
    private void Start()
    {
        playerController?.OnGameStart();
    }

    private void FixedUpdate()
    {
        playerController.Move();
        
    }

    private void Update()
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
}
