using UnityEngine;
using System.Collections;

public class PickableObject : MonoBehaviour {
	
	public Transform myTransform;
	public Rigidbody myRigidBody;
	public bool usePreferedDir;
	public Vector3 prefereredDir;
	public bool isUsable;
	public int pickerID;
	public Vector3 offset;

	public bool useHaptics;
	public float hapticsForce;

	public bool isPickedUp;


	public virtual void Awake()
	{
		myRigidBody = gameObject.GetComponent<Rigidbody>();
		myTransform = transform;
	}

	public virtual void PickUp(Transform parent)
	{
		pickerID = -1;
		pickerID = parent.gameObject.GetInstanceID ();

		if (myTransform.parent != null) 
		{
			myTransform.parent = null;
		}

		if(myRigidBody != null)  
		{
			myRigidBody.isKinematic = true;
		}

		myTransform.parent = parent;
		myTransform.localPosition = offset;

		if (usePreferedDir) 
		{
			myTransform.localRotation = Quaternion.Euler(prefereredDir); 
		}

		isPickedUp = true;
	}

	public virtual void Use()
	{
		Debug.Log ("Used: "+gameObject.name);
	}

	public virtual void Drop()
	{
		pickerID = -1;

		if (myRigidBody != null) {
			myRigidBody.isKinematic = false;
		}

		myTransform.parent = null;
		isPickedUp = false;
	}

	public virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.TransformPoint(offset),0.05f);
	}

}
