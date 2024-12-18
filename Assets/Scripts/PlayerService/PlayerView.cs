using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private PlayerController playerController;
    [SerializeField] Transform jumpRadiusPosition;
    [SerializeField] float jumpRadius;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Renderer playerMeshRenderer;
    [SerializeField] float swipeThreshold;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Start()
    {
        playerController?.OnGameStart();
        startTouchPosition=new Vector2 (0,0);
        endTouchPosition=new Vector2 (0,0);
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
            HandleTouchInput();

            HandleKeyBoardInput();
        }

    }

    private void HandleKeyBoardInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerController.MoveLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerController.MoveLane(+1);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckForJump();
        }
    }

    private void CheckForJump()
    {
        bool isGround = Physics.CheckSphere(jumpRadiusPosition.position, jumpRadius, groundLayerMask);
        if (isGround)
        {
            playerController.PerformJump();
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 swipeDelta = endTouchPosition - startTouchPosition;

            if(swipeDelta.magnitude > swipeThreshold)
            {
                if(Mathf.Abs(swipeDelta.x)>Mathf.Abs(swipeDelta.y))
                {
                    if(swipeDelta.x>0)
                    {
                        playerController.MoveLane(+1);
                    }
                    else
                    {
                        playerController.MoveLane(-1);
                    }
                }
                else
                {
                    if(swipeDelta.y>0)
                    {
                        CheckForJump();
                    }
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
