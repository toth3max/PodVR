using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

    public Transform AttachedTo;
    public Vector3 Distance;
    public Rigidbody RigidBody;

	// Use this for initialization
	void Start ()
    {
        RigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PickUp(TrackerScript tracker)
    {
        AttachedTo = tracker.transform;
        RigidBody.useGravity = false;
        RigidBody.velocity = new Vector3();
    }

    public void Drop()
    {
        AttachedTo = null;
        RigidBody.useGravity = true;
        RigidBody.velocity = new Vector3();
    }

    void FixedUpdate()
    {
        if (AttachedTo != null) {
            RigidBody.MovePosition(AttachedTo.transform.position + (Quaternion.LookRotation(AttachedTo.transform.forward) * Distance));
            RigidBody.MoveRotation(AttachedTo.transform.rotation);
        }
    }
}
