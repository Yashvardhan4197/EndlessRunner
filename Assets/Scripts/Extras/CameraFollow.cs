using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float smoothSpeed;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] Transform startPosition;

    public void OnGameStart()
    {
        transform.position = startPosition.position + offset;
    }


    private void FixedUpdate()
    {
        Vector3 targePosition=offset+target.position;
        Vector3 smoothedPos= Vector3.Lerp(transform.position, targePosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPos;
    }
}
