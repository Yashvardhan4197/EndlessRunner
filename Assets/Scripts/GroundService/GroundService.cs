
using System.Collections.Generic;
using UnityEngine;

public class GroundService
{
    private GroundObjectPool groundObjectPool;
    private PickupPool pickupPool;
    private float lastSpawnedGroundObjectOffsetZ;
    private float offsetZ;
    private float spawnOffsetY;
    private int pickupCount;
    public GroundService(GroundObjectView groundObjectView,PickupView pickupView,float offsetZ,float offsetY,int pickupCount)
    {
        groundObjectPool = new GroundObjectPool(groundObjectView);
        pickupPool = new PickupPool(pickupView);
        this.offsetZ = offsetZ;
        this.spawnOffsetY = offsetY;
        this.pickupCount=pickupCount;
        OnGameStart();
    }

    public void OnGameStart()
    {
        lastSpawnedGroundObjectOffsetZ = 0;
    }

    public void SpawnGroundObject()
    {
        GroundObjectController tempController= groundObjectPool.GetPooledItem();
        lastSpawnedGroundObjectOffsetZ += offsetZ;
        tempController.ActivateView();
        tempController.SetGroundObjectPosition(new Vector3(0,spawnOffsetY,lastSpawnedGroundObjectOffsetZ));
        tempController.SpawnObstacle();
        //SpawnPickup
        List<Vector3>currentlySpawnedPickups = new List<Vector3>();
        SpawnPickup(tempController.GetPickupBounds(),currentlySpawnedPickups);
    }

    private void SpawnPickup(BoxCollider boxCollider,List<Vector3> currentlySpawnedPickups)
    {
        Debug.Log("Pickup Spawned");
        int temp = pickupCount;
        while(temp>0)
        {
            PickupController pickupController = pickupPool.GetPooledItem();
            pickupController.SetPickUpTransform(boxCollider,lastSpawnedGroundObjectOffsetZ,currentlySpawnedPickups);
            pickupController.ActivatePickup();
            temp--;
        }

    }


    public GroundObjectPool GetGroundObjectPool() => groundObjectPool;
    public PickupPool GetPickupPool() => pickupPool;
}

