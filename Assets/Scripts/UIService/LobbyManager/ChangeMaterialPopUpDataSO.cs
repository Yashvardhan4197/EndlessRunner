using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="ChangeMaterialPopUpCollectionData",menuName = "ScriptableObjects/ChangeMaterialPopUpCollection")]
public class ChangeMaterialPopUpDataSO: ScriptableObject
{
    [Serializable]
    public class ChangeMaterialData
    {
        public string name;
        public Sprite image;
        public Material material;
    }

    [SerializeField] ChangeMaterialData[] changeMaterialDataCollection;


    public ChangeMaterialData[] ChangeMaterialDataCollection { get { return changeMaterialDataCollection; } }

}