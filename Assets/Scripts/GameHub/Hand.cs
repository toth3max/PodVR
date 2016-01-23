using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Hand : MonoBehaviour
{
    public Transform AttachedTracker;

	// Update is called once per frame
	void Update () {
        if (AttachedTracker != null) {
            transform.position = AttachedTracker.position;
            transform.rotation = AttachedTracker.rotation;
        }
	}
}
