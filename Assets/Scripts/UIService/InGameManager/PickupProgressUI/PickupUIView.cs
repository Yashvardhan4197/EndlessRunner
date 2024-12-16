using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUIView : MonoBehaviour
{
    [SerializeField] Image pickupImage;
    [SerializeField] Image pickupProgressBar;
    private float maxTime;
    public float MaxTime {  get { return maxTime; } } 
    public Image GetPickUpImage() => pickupImage;
    public Image GetPickUpProgressBar() => pickupProgressBar;

    public void SetMaxTime(float maxTime)=>this.maxTime = maxTime;
}
