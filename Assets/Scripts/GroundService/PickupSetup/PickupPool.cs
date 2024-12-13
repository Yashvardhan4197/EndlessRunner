using System.Collections.Generic;
using System;

public class PickupPool
{
    private PickupView pickupView;
    private List<PooledItem> pooledItems = new List<PooledItem>();

    public PickupPool(PickupView pickupView)
    {
        this.pickupView = pickupView;
    }

    private PickupController CreatePooledItem()
    {
        PooledItem newItem = new PooledItem();
        newItem.isUsed = true;
        newItem.pickupController = new PickupController(pickupView);
        pooledItems.Add(newItem);
        return newItem.pickupController;
    }

    public PickupController GetPooledItem()
    {
        PooledItem item = pooledItems.Find(item => !item.isUsed);
        if (item != null)
        {
            item.isUsed = true;
            return item.pickupController;
        }
        return CreatePooledItem();
    }

    public void ReturnToPool(PickupController toReturnController)
    {
        PooledItem item = pooledItems.Find(item => item.pickupController == toReturnController);
        if (item != null)
        {
            item.isUsed = false;
        }
    }

    public void OnGameStart()
    {
        foreach(PooledItem item in pooledItems)
        {
            //implement later
        }
    }

    public class PooledItem
    {
        public PickupController pickupController;
        public bool isUsed;
    }
}