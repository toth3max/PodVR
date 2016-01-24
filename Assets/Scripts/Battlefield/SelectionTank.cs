using UnityEngine;
using System.Collections;

public class SelectionTank : MonoBehaviour {

    public Transform Attach;
    public Vector3 Distance;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    transform.position = Attach.transform.position + (Quaternion.LookRotation(Attach.transform.forward) * Distance);
	}
}
