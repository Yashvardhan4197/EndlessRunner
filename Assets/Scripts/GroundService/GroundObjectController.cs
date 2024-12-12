

using System.Collections.Generic;
using UnityEngine;

public class GroundObjectController
{
    private GroundObjectView groundObjectView;
    private List<ObstacleCollection> obstacleCollections;
    public GroundObjectController(GroundObjectView groundObjectView)
    {
        this.groundObjectView=Object.Instantiate(groundObjectView);
        ActivateView();
        this.groundObjectView.SetController(this);
        obstacleCollections = this.groundObjectView.GetObstacleCollection();
    }

    public void ActivateView()
    {
        groundObjectView.gameObject.SetActive(true);
    }

    public void SetGroundObjectPosition(Vector3 position)
    {
        groundObjectView.transform.position = position;
    }

    public void ReturnGroundObject()
    {
        groundObjectView.gameObject.SetActive(false);
        GameService.Instance.GroundService.GetGroundObjectPool().ReturnToPool(this);
    }

    public void SpawnObstacle()
    {
        ResetObstacles();
        int index=Random.Range(0,obstacleCollections.Count);
        if (obstacleCollections[index].obstacleName==Obstacles.SMALL)
        {
            int randLane = Random.Range(0, 3);
            switch (randLane)
            {
                case 0:
                    {
                        obstacleCollections[index].ObstacleGB.transform.localPosition = new Vector3(
                            obstacleCollections[index].ObstacleGB.transform.localPosition.x - obstacleCollections[index].offsetX,
                            obstacleCollections[index].ObstacleGB.transform.localPosition.y,
                            obstacleCollections[index].ObstacleGB.transform.localPosition.z);
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        obstacleCollections[index].ObstacleGB.transform.localPosition = new Vector3(
                            obstacleCollections[index].ObstacleGB.transform.localPosition.x + obstacleCollections[index].offsetX,
                            obstacleCollections[index].ObstacleGB.transform.localPosition.y,
                            obstacleCollections[index].ObstacleGB.transform.localPosition.z);
                        break;
                    }
            }
            int spawnSecond = Random.Range(0, 2);
            if (spawnSecond == 1)
            {
                SpawnSecondObstacle(index, randLane);
            }
        }
        obstacleCollections[index].ObstacleGB.SetActive(true);
    }

    private void SpawnSecondObstacle(int index, int randLane)
    {
        int index2 = Random.Range(0, obstacleCollections.Count);
        while (obstacleCollections[index2].obstacleName == Obstacles.BIG || index2 == index)
        {
            index2 = Random.Range(0, obstacleCollections.Count);
        }
        int randLane2 = Random.Range(0, 3);
        while (randLane2 == randLane)
        {
            randLane2 = Random.Range(0, 3);
        }

        switch (randLane2)
        {
            case 0:
                {
                    obstacleCollections[index2].ObstacleGB.transform.localPosition = new Vector3(
                        obstacleCollections[index2].ObstacleGB.transform.localPosition.x - obstacleCollections[index2].offsetX,
                        obstacleCollections[index2].ObstacleGB.transform.localPosition.y,
                        obstacleCollections[index2].ObstacleGB.transform.localPosition.z);
                    break;
                }
            case 1:
                {
                    break;
                }
            case 2:
                {
                    obstacleCollections[index2].ObstacleGB.transform.localPosition = new Vector3(
                        obstacleCollections[index2].ObstacleGB.transform.localPosition.x + obstacleCollections[index2].offsetX,
                        obstacleCollections[index2].ObstacleGB.transform.localPosition.y,
                        obstacleCollections[index2].ObstacleGB.transform.localPosition.z);
                    break;
                }
        }
        obstacleCollections[index2].ObstacleGB.SetActive(true);
    }

    private void ResetObstacles()
    {
        foreach(var element in obstacleCollections)
        {
            element.ObstacleGB.transform.localPosition = element.defaultPosition;
            element.ObstacleGB.SetActive(false);
        }
    }
}