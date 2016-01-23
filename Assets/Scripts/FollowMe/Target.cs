using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public List<Follower> FollowersGathered;
    public Text Text;

	// Use this for initialization
	void Start () {
        FollowersGathered = new List<Follower>();
        Text = GetComponent<Text>();
	}
	
    public void AddFollower(Follower follower)
    {
        FollowersGathered.Add(follower);
        UpdateText();
    }

    public void RemoveFollower(Follower follower)
    {
        FollowersGathered.Remove(follower);

    }

    public void UpdateText()
    {
        Text.text = string.Format("{0}/{10}", FollowersGathered.Count, FollowerManager.Instance.SpawnAmount);
        UpdateText();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
