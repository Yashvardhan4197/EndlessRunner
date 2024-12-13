using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupView : MonoBehaviour
{
    private PickupController pickupController;
    private int currentlySetPickupIndex;
    [SerializeField] float rotationSpeed;
    [SerializeField] PickupCollection[] pickupCollection;
    public void SetController(PickupController pickupController )
    {
        this.pickupController = pickupController;
    }

    private void Update()
    {
        pickupCollection[currentlySetPickupIndex]?.pickupBody.transform.Rotate(0, rotationSpeed * Time.deltaTime,0);
    }

    public PickupCollection[] GetPickupCollection() => pickupCollection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerView>()==true||other.gameObject.layer==6)
        {
            pickupController.ReturnToPool();
        }
    }

    public void SetPickupIndex(int index)=>currentlySetPickupIndex = index;

}

[Serializable] 
public class PickupCollection
{
    public PickupType pickupType;
    public GameObject pickupBody;
}

public enum PickupType
{
    COIN
}