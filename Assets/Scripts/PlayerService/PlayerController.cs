using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float laneDistance;
    private int currentLane;
    private float targetXPos;


    private void Start()
    {
        currentLane = 0;
        targetXPos = transform.position.x;
    }
    private void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.A))
        {
            MoveLane(-1);
        }else if(Input.GetKeyDown(KeyCode.D))
        {
            MoveLane(+1);
        }
    }

    private void MoveLane(int lane)
    {
        currentLane = Math.Clamp(currentLane + lane, -1, 1);
        targetXPos = currentLane * laneDistance;
    }

    private void Move()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed);

        Vector3 newPos=new Vector3(targetXPos,rb.position.y,rb.position.z);
        rb.MovePosition(Vector3.Lerp(rb.position, newPos,horizontalSpeed*Time.deltaTime));
    }
}
