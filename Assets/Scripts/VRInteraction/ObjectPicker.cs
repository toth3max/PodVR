using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ObjectPicker : MonoBehaviour {

	public float pickDistance = 2;
	public PickableObject currentPickedItem;
	private Ray ray;
	private RaycastHit hit;

	public GameObject prefab;
	public Rigidbody attachPoint;

	public bool useCollider;

	SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

    public bool debug;
	
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();

		if (useCollider) 
		{
			gameObject.AddComponent<SphereCollider>();
			gameObject.GetComponent<SphereCollider>().radius = 0.05f;
		}
	}

	void FixedUpdate()
	{

        if (!debug)
        {
            var device = SteamVR_Controller.Input((int)trackedObj.index);

            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (currentPickedItem != null && currentPickedItem.isUsable)
                {
                    if (currentPickedItem.useHaptics)
                    {
						UseHaptics ((ushort)currentPickedItem.hapticsForce);
                    }

                    currentPickedItem.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    PickedupObject();
                }
                Debug.DrawRay(transform.position, transform.forward * pickDistance);
            }
            else if (device.GetTouchUp((SteamVR_Controller.ButtonMask.Trigger)))
            {
                if (currentPickedItem != null)
                {
                    if (!currentPickedItem.isUsable)
                    {
                        if (currentPickedItem.pickerID == this.gameObject.GetInstanceID())
                        {
                            currentPickedItem.Drop();
                            if (currentPickedItem.myRigidBody)
                            {
                                currentPickedItem.GetComponent<Rigidbody>();
                                var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
                                if (origin != null)
                                {
                                    currentPickedItem.myRigidBody.velocity = origin.TransformVector(device.velocity);
                                    currentPickedItem.myRigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
                                }
                                else
                                {
                                    currentPickedItem.myRigidBody.velocity = device.velocity;
                                    currentPickedItem.myRigidBody.angularVelocity = device.angularVelocity;
                                }

                                currentPickedItem.myRigidBody.maxAngularVelocity = currentPickedItem.myRigidBody.angularVelocity.magnitude;

                            }
                        }
                    }
                }
            }
            else if (device.GetTouchUp((SteamVR_Controller.ButtonMask.Grip)))
            {
                if (currentPickedItem != null)
                {
                    if (currentPickedItem.isUsable)
                    {
                        currentPickedItem.Drop();

                        if (currentPickedItem.myRigidBody)
                        {
                            currentPickedItem.GetComponent<Rigidbody>();
                            var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
                            if (origin != null)
                            {
                                currentPickedItem.myRigidBody.velocity = origin.TransformVector(device.velocity);
                                currentPickedItem.myRigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
                            }
                            else
                            {
                                currentPickedItem.myRigidBody.velocity = device.velocity;
                                currentPickedItem.myRigidBody.angularVelocity = device.angularVelocity;
                            }

                            currentPickedItem.myRigidBody.maxAngularVelocity = currentPickedItem.myRigidBody.angularVelocity.magnitude;

                        }

                        currentPickedItem = null;
                    }
                }
            }
        }

	}

	void PickedupObject()
	{
		ray = new Ray(transform.position - (transform.forward * 1),transform.forward);

		if(Physics.SphereCast(ray,0.1f,out hit,pickDistance))
		{
			PickableObject objectPickedUp = hit.collider.gameObject.GetComponent<PickableObject>();

			if(objectPickedUp != null)
			{
				currentPickedItem = objectPickedUp;
				currentPickedItem.PickUp(transform);

			}
		}
	}

    void Update()
    {
        if (debug)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentPickedItem != null && currentPickedItem.isUsable)
                {
                    currentPickedItem.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    PickedupObject();
                }
                Debug.DrawRay(transform.position, transform.forward * pickDistance);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (currentPickedItem != null)
                {
                    if (!currentPickedItem.isUsable)
                    {
                        if (currentPickedItem.pickerID == this.gameObject.GetInstanceID())
                        {
                            currentPickedItem.Drop();
                        }
                    }
                }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                if (currentPickedItem != null)
                {
                    if (currentPickedItem.isUsable)
                    {
                        currentPickedItem.Drop();
                    }
                }
                currentPickedItem = null;
            }
            else if(Input.GetMouseButtonUp(2))
            {
                if (currentPickedItem != null)
                {
                    if (currentPickedItem.isUsable)
                    {
                        currentPickedItem.Drop();
                    }
                }

                currentPickedItem = null;
            }
        }
    }

	public void UseHaptics(uint force)
	{
		ushort hapticForce = (ushort)force;
		SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
	}
}
