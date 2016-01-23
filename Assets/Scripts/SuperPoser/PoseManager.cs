using UnityEngine;
using System.Collections;

public class PoseManager : MonoBehaviour {

    public bool LeftTriggered, RightTriggered, HeadTriggered;
    public GameObject[] SuperPoses;
    private int numPoses;
    public int poseIndex;

	// Use this for initialization
	void Start () {
        LeftTriggered = RightTriggered = HeadTriggered = false;
        numPoses = SuperPoses.Length;
	}
	
	// Update is called once per frame
	void Update () {
	    if(LeftTriggered && RightTriggered && HeadTriggered)
        {
            //Pose completed
            poseIndex++;
            //Go to next pose
            //Or if all poses done, win
            if(poseIndex < numPoses)
            {
                //We won
            }
        }
	}
}
