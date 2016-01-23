using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvilTree : MonoBehaviour
{
    public float Range;
    public Follower[] Followers;

	// Use this for initialization
	void Start ()
    {
        Followers = GameObject.FindObjectsOfType<Follower>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var followersInRange = new List<Follower>();

        foreach (var follower in Followers) {
            if ((Vector3.Distance(transform.position, follower.transform.position) <= Range)) {
                if (!follower.HasSetPosition) {
                    follower.SetTarget(transform.position);
                }
            }
        }
	}
}
