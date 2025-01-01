
using UnityEngine;

public class PickupPool:GenericPool<PickupController>
{
    private PickupView pickupView;
    private PickupDataSO pickupDataSO;
    private Transform pickupParent;

    public PickupPool(PickupView pickupView,PickupDataSO pickupDataSO,Transform pickupParent)
    {
        this.pickupView = pickupView;
        this.pickupParent = pickupParent;
        GameService.Instance.GameStartAction += OnGameStart;
        this.pickupDataSO = pickupDataSO;
    }

    public override PickupController CreateItem()
    {
        return new PickupController(pickupView, pickupDataSO, pickupParent);
    }

    public void OnGameStart()
    {
        foreach(var item in PooledItems)
        {
            item.controller.ReturnToPool();
        }
    }

}