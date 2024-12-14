using System.Collections.Generic;
using UnityEngine;

public class PickupController
{
    private PickupView pickupView;
    private int currentlyActiveIndex;
    public int CurrentlyActiveIndex {  get { return currentlyActiveIndex; } }
    public PickupController(PickupView pickupView)
    {

        this.pickupView = Object.Instantiate(pickupView);
        this.pickupView.SetController(this);
        currentlyActiveIndex = -1;
    }

    public void EnableCoinPickup()
    {
        pickupView.gameObject.SetActive(true);
        //ChangeAfterWords
        DisableAllInsidePickup();
        GetPickupBody(PickupType.COIN).gameObject.SetActive(true);
        currentlyActiveIndex = 0;
    }

    public void EnablePowerPickup()
    {
        pickupView.gameObject.SetActive(true);
        DisableAllInsidePickup();
        int rand=Random.Range(1,pickupView.GetPickupCollection().Length);
        GetPickupBody(pickupView.GetPickupCollection()[rand].pickupType).gameObject.SetActive(true);
        currentlyActiveIndex=rand;
    }

    private void DisableAllInsidePickup()
    {
        foreach(var item in  pickupView.GetPickupCollection())
        {
            item.pickupBody.SetActive(false);
        }
    }

    private GameObject GetPickupBody(PickupType pickupType)
    {
        foreach(var item in pickupView.GetPickupCollection())
        {
            if(item.pickupType== pickupType)
            {
                return item.pickupBody;
            }
        }
        return null;
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
        currentlyActiveIndex = -1;
    }

    public void ActivatePickupPower()
    {
        //Add more PickupType logic here
        if(pickupView.GetPickupCollection()[currentlyActiveIndex].pickupType== PickupType.COIN)
        {
            Debug.Log("Score Increased");
        }
        else if (pickupView.GetPickupCollection()[currentlyActiveIndex].pickupType==PickupType.DOUBLE_SPEED)
        {
            Debug.Log("Speedincreased");
        }else if(pickupView.GetPickupCollection()[currentlyActiveIndex].pickupType == PickupType.DOUBLE_COIN)
        {
            Debug.Log("Coin Doubled");
        }
    }
}