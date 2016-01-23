using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    public bool BeingHeld = false;
    public Transform PositionAndOrientationToSnapTo;
    private GameObject controllerPickingUpObject;
    private Rigidbody rigidBodyOfObject;

    public Rigidbody AttachPoint;
    private FixedJoint joint;

    //Debug
    public Transform ControllerToSnapTo;

    public SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        //trackedObj = GetComponent<SteamVR_TrackedObject>();
        
    }

    // Use this for initialization
    void Start () {
        rigidBodyOfObject = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {


        //Debug
        var _device = SteamVR_Controller.Input((int)trackedObj.index);
        if (Input.GetMouseButtonDown(0) 
            || _device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)){
            if (!BeingHeld)
            {
                Debug.Log("Snapping");
                SnapToController(ControllerToSnapTo);
            }
            else
            {
                Debug.Log("Dropping");
                DropObject();
            }
        }
	}

    //If the object has an action, initiate it here
    public void Interact()
    {
        if (BeingHeld)
        {

        }
        else
        {
            Debug.Log("Object is not currently held, so it can't be interacted with");
        }
    }

    //What orientation and position should the 
    //object snap to the controller
    public void SnapToController(Transform _controllerPosition)
    {
        //Debug
        controllerPickingUpObject = _controllerPosition.gameObject;

        /*
        BeingHeld = true;
        //Parent the object to the controller that picked it up
        transform.parent = controllerPickingUpObject.transform;
        transform.localPosition = PositionAndOrientationToSnapTo.position;
        transform.localRotation = PositionAndOrientationToSnapTo.rotation;

        rigidBodyOfObject.useGravity = false;
        */
        Debug.Log("Trying to snap");
        BeingHeld = true;
        transform.position = AttachPoint.transform.position;
        joint = transform.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = AttachPoint;
    }

    public void DropObject()
    {
        /*
        BeingHeld = false;
        //Unparent the object from the controller that picked it up
        transform.parent = null;
        rigidBodyOfObject.useGravity = true;
        */
        Debug.Log("Trying to drop");
        BeingHeld = false;
        Object.DestroyImmediate(joint);
        joint = null;

    }
}
