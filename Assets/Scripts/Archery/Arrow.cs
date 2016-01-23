using UnityEngine;
using System.Collections;

public class Arrow : PickableObject {

    public bool aiming;
	public bool isFlying;
    private Collider myCollider;
	private Bow myBow;
	public Transform targetToLookAt;
	private Vector3 attachPoint;
	private Transform arrowMesh;
	public float power;
	private ObjectPicker myBowsPicker;

    void Start()
    {
        myCollider = gameObject.GetComponent<Collider>();
		arrowMesh = transform.GetChild (0);
    }

    public override void PickUp(Transform parent)
    {
        base.PickUp(parent);
        myCollider.isTrigger = true;
    } 

	void Update()
	{
		if (aiming) 
		{
			Quaternion lookDir = Quaternion.LookRotation (transform.TransformPoint(offset) - targetToLookAt.position,Vector3.up);
			transform.rotation = lookDir;

			transform.localPosition = Vector3.zero;

			//arrowMesh.localPosition = new Vector3 (arrowMesh.localPosition.x, arrowMesh.localPosition.y, toPoint.z);

			arrowMesh.position = targetToLookAt.position;
			arrowMesh.rotation = transform.rotation;
		

			power = Vector3.Distance (myBow.transform.position ,  targetToLookAt.position) * myBow.forceMultiplier;
		}


	}

	void FixedUpdate()
	{
		if (isFlying) 
		{
			//Ray hitRay = new Ray (arrowMesh.GetChild (0).position + arrowMesh.GetChild(0).forward * 0.15f,arrowMesh.GetChild (0).forward);
			//RaycastHit hit;

			/*if (Physics.SphereCast (hitRay, 0.02f,out hit, 1)) 
			{
				arrowMesh.GetChild (0).gameObject.GetComponent<Rigidbody>().isKinematic = true;
				arrowMesh.GetChild (0).gameObject.GetComponent<Rigidbody>().useGravity = false;
			}*/

		}
	}
		

    public override void Drop()
    {
        base.Drop();

        if (aiming)
        {
			Fire(power);
            aiming = false;
        

	        myCollider.isTrigger = true;
			myCollider.enabled = false;
			isFlying = true;
		}
    }

    public void Fire(float force)
    {
		arrowMesh.parent = null;
		arrowMesh.GetChild (0).gameObject.AddComponent<BoxCollider> ();
		arrowMesh.GetChild (0).gameObject.AddComponent<Rigidbody> ();
		arrowMesh.GetChild (0).gameObject.GetComponent<Rigidbody>().AddForce(arrowMesh.GetChild(0).forward * force,ForceMode.VelocityChange);

    }
    
    void OnTriggerEnter(Collider other)
    {
		Debug.Log ("other: "+other.name);

        if (other.GetComponent<Bow>() && !aiming)
        {
            Bow bow = other.GetComponent<Bow>();
			myBow = bow;

			if (isPickedUp && bow.isPickedUp)
            {
				bow.currentArrow = this;
                aiming = true;
				targetToLookAt = transform.parent;
				transform.parent = bow.transform;
				attachPoint = transform.localPosition;
				transform.localPosition = Vector3.zero;
				myBowsPicker = myBow.myTransform.parent.GetComponent<ObjectPicker> ();
            }
        }
    }
}
