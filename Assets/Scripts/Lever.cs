using UnityEngine;
using System.Collections;

public class Lever : PickableObject 
{
	public Vector3 allowedDir;
	public float maxAngle = 90;
	public Transform leverPivot;
	public Transform lookTarget;
	public float releaseDistance = 4;

	private Vector3 targetPostition;

	public override void PickUp (Transform parent)
	{
		pickerID = parent.gameObject.GetInstanceID();
		lookTarget = parent;
	}

	public override void Drop ()
	{
		pickerID = -1;
		lookTarget = null;
	} 
	
	void Update()
	{
		if (lookTarget) 
		{

			if(allowedDir.x >= 1 && allowedDir.y == 0 && allowedDir.z == 0)
			{
				targetPostition = new Vector3(leverPivot.position.x,lookTarget.position.y,lookTarget.position.z ) ;
			}
			else if(allowedDir.x == 0 && allowedDir.y == 0 && allowedDir.z >= 1)
			{
				targetPostition = new Vector3( lookTarget.position.x,lookTarget.position.y,leverPivot.position.z ) ;
			}
			else if(allowedDir.x == 0 && allowedDir.y >= 1 && allowedDir.z == 0)
			{
				targetPostition = new Vector3(lookTarget.position.x,leverPivot.position.y,lookTarget.position.z ) ;
			}



			leverPivot.LookAt( targetPostition ) ;
		
			if(Vector3.Distance(leverPivot.position,lookTarget.position) > releaseDistance)
			{
				Drop();
			}
		}


	}
}
