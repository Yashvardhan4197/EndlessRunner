
using UnityEngine;

public class GroundObjectPool:GenericPool<GroundObjectController>
{
    private GroundObjectView groundObjectView;
    private Transform groundParent;

    public GroundObjectPool(GroundObjectView groundObjectView,Transform groundParent)
    {
        this.groundObjectView = groundObjectView;
        this.groundParent = groundParent;
        GameService.Instance.GameStartAction += OnGameStart;
    }

    public override GroundObjectController CreateItem()
    {
        return new GroundObjectController(groundObjectView, groundParent);
    }

    public void OnGameStart()
    {
       foreach(var item in PooledItems)
        {
            item.controller.ReturnGroundObject();
        }
    }

}
