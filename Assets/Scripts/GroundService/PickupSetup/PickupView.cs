using System;
using UnityEngine;

public class PickupView : MonoBehaviour
{
    private PickupController pickupController;
    [SerializeField] float rotationSpeed;
    [SerializeField] PickupCollection[] pickupCollection;
    public void SetController(PickupController pickupController )
    {
        this.pickupController = pickupController;
    }

    private void Update()
    {
        pickupCollection[pickupController.CurrentlyActiveIndex]?.pickupBody.transform.Rotate(0, rotationSpeed * Time.deltaTime,0);
    }

    public PickupCollection[] GetPickupCollection() => pickupCollection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            pickupController.ReturnToPool();
        }
        if (other.gameObject.GetComponent<PlayerView>()==true)
        {
            pickupController.ActivatePickupPower();
            pickupController.ReturnToPool();
        }
    }

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