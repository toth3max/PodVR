using UnityEngine;
using System.Collections;

public class PoseManager : MonoBehaviour {

    public bool LeftTriggered, RightTriggered, HeadTriggered;
    public GameObject[] SuperPoses;
    private int numPoses;
    public int poseIndex = 0;
    public AudioSource WinAudioSource;
    public AudioClip CorrectSound, WinSound;
    public bool Triggered = false;

	// Use this for initialization
	void Start () {
        LeftTriggered = RightTriggered = HeadTriggered = false;
        numPoses = 4;
        SuperPoses[poseIndex].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
        if (!Triggered)
        {
            if (LeftTriggered && RightTriggered && HeadTriggered)
            {
                Triggered = true;
                Invoke("WaitThenReact", 2f);
            }
        }
    }

    public void WaitThenReact()
    {
        SuperPoses[poseIndex].SetActive(false);
        //Pose completed
        poseIndex++;
        //Go to next pose
        //Or if all poses done, win

        if (poseIndex < numPoses)
        {
            SuperPoses[poseIndex].SetActive(true);
        }
        else
        {
            //We won
            PlayWinSound();
        }

        Invoke("WaitMoreThenReset", 10f);
    }

    public void WaitMoreThenReset()
    {
        Triggered = false;
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
