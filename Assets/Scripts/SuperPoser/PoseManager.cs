using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PoseManager : MonoBehaviour {

    public bool LeftTriggered, RightTriggered, HeadTriggered;
    public GameObject[] SuperPoses;
    private int numPoses;
    public int poseIndex = 0;
    public AudioSource WinAudioSource;
    public AudioClip CorrectSound, WinSound, UltimateWinSound;
    public bool Triggered = false;
    private GameObject[] randomizedArray;


	// Use this for initialization
	void Start () {
        LeftTriggered = RightTriggered = HeadTriggered = false;
        numPoses = 5;

        randomizedArray = SuperPoses;
        reshuffle(randomizedArray);
        randomizedArray[poseIndex].SetActive(true);

        //SuperPoses[poseIndex].SetActive(true);

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
        //SuperPoses[poseIndex].SetActive(false);
        randomizedArray[poseIndex].SetActive(false);
        //Pose completed
        poseIndex++;
        //Go to next pose
        //Or if all poses done, win
        PlayWinSound();

        if (poseIndex < numPoses)
        {
            //SuperPoses[poseIndex].SetActive(true);
            randomizedArray[poseIndex].SetActive(true);
        }
        else
        {
            //We won
            PlayUltimateWinSound();
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

    public void PlayUltimateWinSound()
    {
        Debug.Log("Playing Ultimate Win sound");
        WinAudioSource.clip = UltimateWinSound;
        WinAudioSource.Play();
    }

    void reshuffle(GameObject[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            GameObject tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

}
