using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour
{
    public Transform Target;

	// Update is called once per frame
	void Update ()
    {
        if (Target != null) {
            transform.position = Target.position;
            transform.rotation = Target.rotation;
        }
	}
}
