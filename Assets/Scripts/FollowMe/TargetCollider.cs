using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class TargetCollider : MonoBehaviour
{
    public Target Target;
	// Use this for initialization
	void Start ()
    {
        Target = GetComponentInParent<Target>();
	}
	
    void OnTriggerEnter(Collider collider)
    {
        var follower = collider.GetComponent<Follower>();

        if (follower != null) {
            Target.AddFollower(follower);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var follower = collider.GetComponent<Follower>();

        if (follower != null) {
            Target.RemoveFollower(follower);
        }
    }
}
