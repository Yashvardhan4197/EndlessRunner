
using UnityEngine;

public class GroundObjectView : MonoBehaviour
{
    private GroundObjectController groundObjectController;
    [SerializeField] float reachingSpeed;
    private void Update()
    {
        transform.position=Vector3.Lerp(transform.position,new Vector3(0,0,transform.position.z),reachingSpeed*Time.deltaTime);
    }

    public void SetController(GroundObjectController groundObjectController)
    {
        this.groundObjectController = groundObjectController;
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.layer==6)
        {
            groundObjectController?.ReturnGroundObject();
            
        }
    }
}
