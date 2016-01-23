using UnityEngine;
using System.Collections;

public class Pod : MonoBehaviour
{
    public PodEnum PodNumber = PodEnum.None;
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        var rootObject = LevelCache.LevelMap[LevelToLoad];
        rootObject.gameObject.SetActive(true);

        var matchingPod = GetPodOfPodNumber(MatchingPodNumber, rootObject);

        if (matchingPod == null) {
            Debug.LogError("Failed to find pod " + MatchingPodNumber.ToString() + " in room " + LevelToLoad);
        } else {

        }
    }

    private Pod GetPodOfPodNumber(PodEnum number, RootObject rootObject)
    {
        foreach (var pod in rootObject.GetComponentsInChildren<Pod>()) {
            if (pod.PodNumber == number) {
                return pod;
            }
        }

        return null;
    }
}
