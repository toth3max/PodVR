using UnityEngine;
using System.Collections;

public class Bow : PickableObject 
{

    public Arrow currentArrow;
	public float forceMultiplier = 200;

	public override void PickUp (Transform parent)
	{
		base.PickUp (parent);
		transform.GetComponent<Collider> ().isTrigger = true;
	}
}
