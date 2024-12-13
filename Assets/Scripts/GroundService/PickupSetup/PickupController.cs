using System.Collections.Generic;
using UnityEngine;

public class PickupController
{
    private PickupView pickupView;
    public PickupController(PickupView pickupView)
    {

        this.pickupView = Object.Instantiate(pickupView);
        this.pickupView.SetController(this);
    }

    public void ActivatePickup()
    {
        pickupView.gameObject.SetActive(true);
        //ChangeAfterWords
        pickupView.GetPickupCollection()[0].pickupBody.SetActive(true);
        pickupView.SetPickupIndex(0);
    }

    public void DeactivatePickup()
    {
        foreach(var item in  pickupView.GetPickupCollection())
        {
            item.pickupBody.SetActive(false);
        }
    }

    public void SetPickUpTransform(BoxCollider boxCollider,float offsetZ,List<Vector3>currentlySpawnedPickups)
    {
        Vector3 pos = GetRandomPosition(boxCollider, offsetZ);
        bool validPos = true;
        foreach(var item in currentlySpawnedPickups)
        {
            if(Vector3.Distance(pos,item)<.9f)
            {
                validPos = false;
            }
        }
        if (!validPos)
        {
            SetPickUpTransform(boxCollider, offsetZ, currentlySpawnedPickups);
        }
        else
        {
            pickupView.gameObject.transform.position = pos;
            currentlySpawnedPickups.Add(pos);
        }
    }

    public Vector3 GetRandomPosition(BoxCollider boxCollider, float offsetZ)
    {
        return new Vector3(
            Random.Range(boxCollider.bounds.min.x+.3f, boxCollider.bounds.max.x-.3f),
            Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y),
            Random.Range(offsetZ-5f, offsetZ - 1f)
            ) ;
    }

    public Vector3 GetPickUpTransform() => pickupView.gameObject.transform.position;

    public void ReturnToPool()
    {
        pickupView.gameObject.SetActive(false);
        GameService.Instance.GroundService.GetPickupPool().ReturnToPool(this);
    }
}