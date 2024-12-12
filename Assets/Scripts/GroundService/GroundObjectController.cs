

using UnityEngine;

public class GroundObjectController
{
    private GroundObjectView groundObjectView;

    public GroundObjectController(GroundObjectView groundObjectView)
    {
        this.groundObjectView=Object.Instantiate(groundObjectView);
        ActivateView();
        this.groundObjectView.SetController(this);
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
}