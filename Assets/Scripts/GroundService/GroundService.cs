
using UnityEngine;

public class GroundService
{
    private GroundObjectPool groundObjectPool;
    private float lastSpawnedGroundObjectOffsetZ;
    private float offsetZ;
    private float spawnOffsetY;
    public GroundService(GroundObjectView groundObjectView,float offsetZ,float offsetY)
    {
        groundObjectPool = new GroundObjectPool(groundObjectView);
        this.offsetZ = offsetZ;
        this.spawnOffsetY = offsetY;
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
    }

    public GroundObjectPool GetGroundObjectPool() => groundObjectPool;
}

