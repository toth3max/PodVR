using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Pod : MonoBehaviour
{

	public PodEnum MatchingPodNumber = PodEnum.None;
	public string LevelToLoad = "";
	
	// Use this for initialization
	void Start ()
	{
		if(LevelToLoad == ""){
			Debug.LogWarning("Pod is missing a level to be loaded");
		}
	}
	
	public void LoadLevel()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
