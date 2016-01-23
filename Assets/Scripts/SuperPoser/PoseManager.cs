using UnityEngine;
using System.Collections;

public class PoseManager : MonoBehaviour {

    public bool LeftTriggered, RightTriggered, HeadTriggered;
    public GameObject[] SuperPoses;
    private int numPoses;
    public int poseIndex = 0;
    public AudioSource WinAudioSource;
    public AudioClip CorrectSound, WinSound;

	// Use this for initialization
	void Start () {
        LeftTriggered = RightTriggered = HeadTriggered = false;
        numPoses = SuperPoses.Length;
        SuperPoses[poseIndex].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
	    if(LeftTriggered && RightTriggered && HeadTriggered)
        {
            SuperPoses[poseIndex].SetActive(false);
            //Pose completed
            poseIndex++;
            //Go to next pose
            //Or if all poses done, win
            
            if(poseIndex < numPoses)
            {
                SuperPoses[poseIndex].SetActive(true);
            }
            else
            {
                //We won
                PlayWinSound();
            }
        }
    }

    public void PlayCorrectSound()
    {
        Debug.Log("Playing correct sound");
        WinAudioSource.clip = CorrectSound;
        WinAudioSource.Play();
    }

    public void PlayWinSound()
    {
        Debug.Log("Playing Win sound");
        WinAudioSource.clip = WinSound;
        WinAudioSource.Play();
    }
}
