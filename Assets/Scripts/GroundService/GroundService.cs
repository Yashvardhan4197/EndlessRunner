
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
    private int powerUpSpawningRate;

    public GroundService(GroundObjectView groundObjectView,PickupView pickupView,float offsetZ,float offsetY,int pickupCount, int powerUpSpawningRate,PickupDataSO pickupDataSO,Transform groundParent, Transform pickupParent)
    {
        groundObjectPool = new GroundObjectPool(groundObjectView,groundParent);
        pickupPool = new PickupPool(pickupView,pickupDataSO,pickupParent);
        this.offsetZ = offsetZ;
        this.spawnOffsetY = offsetY;
        this.pickupCount=pickupCount;
        this.powerUpSpawningRate=powerUpSpawningRate;
        GameService.Instance.GameStartAction += OnGameStart;
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
        int temp = pickupCount;
        while(temp>0)
        {
            PickupController pickupController = pickupPool.GetPooledItem();
            pickupController.SetPickUpTransform(boxCollider,lastSpawnedGroundObjectOffsetZ,currentlySpawnedPickups);
            pickupController.EnableCoinPickup();
            temp--;
        }
        SpawnPowerUpPickup(boxCollider, currentlySpawnedPickups);

    }

    private void SpawnPowerUpPickup(BoxCollider boxCollider,List<Vector3> currentlySpawnedPickups)
    {
        int rand = Random.Range(0, 100);
        if(rand<=powerUpSpawningRate)
        {
            PickupController pickupController = pickupPool.GetPooledItem();
            pickupController.SetPickUpTransform(boxCollider, lastSpawnedGroundObjectOffsetZ, currentlySpawnedPickups);
            pickupController.EnablePowerPickup();
        }
    }


    public GroundObjectPool GetGroundObjectPool() => groundObjectPool;
    public PickupPool GetPickupPool() => pickupPool;
}

