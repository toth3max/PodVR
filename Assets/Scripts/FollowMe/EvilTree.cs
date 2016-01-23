using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvilTree : MonoBehaviour
{
    public float AttractRange;
    public float LethalRange;
    public Follower[] Followers;

	// Use this for initialization
	void Start ()
    {
        
	}

    public void GetFollowers( )
    {
        Followers = GameObject.FindObjectsOfType<Follower>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Followers.Length == 0) {
            GetFollowers();
        }

        var followersInRange = new List<Follower>();

        foreach (var follower in Followers) {
            if (follower != null) {
                var distance = Vector3.Distance(transform.position, follower.transform.position);
                if (distance <= LethalRange) {
                    follower.Kill();
                } else if ((Vector3.Distance(transform.position, follower.transform.position) <= AttractRange)) {
                    if (!follower.PlayerHasSetPosition) {
                        follower.SetTarget(transform.position);
                    }
                }
            }
        }
	}
}
