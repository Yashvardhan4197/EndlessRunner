using System.Collections.Generic;
using System;
using UnityEngine;

public class PickupPool
{
    private PickupView pickupView;
    private List<PooledItem> pooledItems = new List<PooledItem>();
    private PickupDataSO pickupDataSO;
    private Transform pickupParent;
    public PickupPool(PickupView pickupView,PickupDataSO pickupDataSO,Transform pickupParent)
    {
        this.pickupView = pickupView;
        this.pickupParent = pickupParent;
        GameService.Instance.GameStartAction += OnGameStart;
        this.pickupDataSO = pickupDataSO;
    }

    private PickupController CreatePooledItem()
    {
        PooledItem newItem = new PooledItem();
        newItem.isUsed = true;
        newItem.pickupController = new PickupController(pickupView,pickupDataSO,pickupParent);
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
            item.pickupController.ReturnToPool();
        }
    }

    public class PooledItem
    {
        public PickupController pickupController;
        public bool isUsed;
    }
}