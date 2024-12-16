using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupUIView : MonoBehaviour
{
    [SerializeField] Image pickupImage;
    [SerializeField] Image pickupProgressBar;
    [SerializeField] TextMeshProUGUI pickupInfoName;
    private float maxTime;
    public float MaxTime {  get { return maxTime; } } 
    public Image GetPickUpImage() => pickupImage;
    public Image GetPickUpProgressBar() => pickupProgressBar;

    public void SetMaxTime(float maxTime)=>this.maxTime = maxTime;

    public TextMeshProUGUI GetPickupName()=> pickupInfoName;
}
