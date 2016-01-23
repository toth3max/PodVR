using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class CameraFloorCollider : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        var positionVector = transform.parent.position;
        positionVector.y = 0;
        transform.position = positionVector;
	}
}
