
using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="PickupData",menuName ="ScriptableObjects/PickupData")]
public class PickupDataSO:ScriptableObject
{
    [Serializable] 
    public class PickupDataElementCollection
    {
        public PickupType PickupType;
        public Sprite PickupImage;
        public int MaxTime;
    }

    [SerializeField] PickupDataElementCollection[] pickupDataElementCollections;

    public PickupDataElementCollection[] PickupDataElementCollections { get { return pickupDataElementCollections;} }

}
