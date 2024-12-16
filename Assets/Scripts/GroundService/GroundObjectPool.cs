

using System.Collections.Generic;
using UnityEngine;

public class GroundObjectPool
{
    private GroundObjectView groundObjectView;
    private List<PooledItem> pooledItems=new List<PooledItem>();
    private Transform groundParent;
    public GroundObjectPool(GroundObjectView groundObjectView,Transform groundParent)
    {
        this.groundObjectView = groundObjectView;
        this.groundParent = groundParent;
        GameService.Instance.GameStartAction += OnGameStart;
    }

    private GroundObjectController CreatePooledItem()
    {
        PooledItem newItem = new PooledItem();
        newItem.isUsed = true;
        newItem.groundObjectController = new GroundObjectController(groundObjectView,groundParent);
        pooledItems.Add(newItem);
        return newItem.groundObjectController;
    }

    public GroundObjectController GetPooledItem()
    {
        PooledItem item = pooledItems.Find(item => !item.isUsed);
        if(item != null)
        {
            item.isUsed = true;
            return item.groundObjectController;
        }
        return CreatePooledItem();
    }

    public void ReturnToPool(GroundObjectController toReturnController)
    {
        PooledItem item=pooledItems.Find(item=>item.groundObjectController==toReturnController);
        if(item!=null)
        {
            item.isUsed = false;
        }
    }

    public void OnGameStart()
    {
       foreach(var item in pooledItems)
        {
            item.groundObjectController.ReturnGroundObject();
        }
    }

    public class PooledItem
    {
        public GroundObjectController groundObjectController;
        public bool isUsed;
    }

}
