using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private PlayerController playerController;

    private void Start()
    {
        playerController?.OnGameStart();
    }

    private void Update()
    {
        playerController.Move();
        if(Input.GetKeyDown(KeyCode.A))
        {
            playerController.MoveLane(-1);
        }else if(Input.GetKeyDown(KeyCode.D))
        {
            playerController.MoveLane(+1);
        }
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public Rigidbody GetRigidbody()=>rb;
}
