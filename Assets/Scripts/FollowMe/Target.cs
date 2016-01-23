using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Target : Manager<Target>
{
    public List<Follower> FollowersGathered;
    public Text Text;
    public AudioClip SuccesClip;
    public AudioSource AudioSource;
    public int TargetCount;

    [HideInInspector]
    public string LevelToLoad;

	// Use this for initialization
	void Start () {
        FollowersGathered = new List<Follower>();
        Text = GetComponentInChildren<Text>();
        AudioSource = GetComponent<AudioSource>();
        UpdateText();
	}
	
    public void AddFollower(Follower follower)
    {
        FollowersGathered.Add(follower);
        UpdateText();

        if (FollowersGathered.Count == TargetCount) {
            Victory();
        }
    }

    public void RemoveFollower(Follower follower)
    {
        FollowersGathered.Remove(follower);
        UpdateText();

    }

    public void UpdateText()
    {
        Text.text = string.Format("{0}/{1}", FollowersGathered.Count, TargetCount);
    }

    public void Victory()
    {
        AudioSource.PlayOneShot(SuccesClip);
        SceneManager.LoadScene(LevelToLoad);
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
