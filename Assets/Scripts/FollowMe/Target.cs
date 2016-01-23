using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    public List<Follower> FollowersGathered;

	// Use this for initialization
	void Start () {
        FollowersGathered = new List<Follower>();
	}
	
    public void AddFollower(Follower follower)
    {
        FollowersGathered.Add(follower);
        Debug.Log("Gathered:" + FollowersGathered.Count);
    }

    public void RemoveFollower(Follower follower)
    {
        FollowersGathered.Remove(follower);
        Debug.Log("Gathered:" + FollowersGathered.Count);

    }
	// Update is called once per frame
	void Update () {
	
	}
}
