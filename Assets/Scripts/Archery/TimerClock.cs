using UnityEngine;
using System.Collections;

public class TimerClock : MonoBehaviour {

    public Transform minutePointer;
    public Transform secondPointer;

    public float distToMoveMinute;
    public float distToMoveSeconds;

    public float secondCounter;
    public float minuteCounter;

    public bool isStarted;

    public Vector3 minuteCurrentRot;
    public Vector3 secondCurrentRot;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(isStarted)
        {
            if(Time.time > secondCounter)
            {
                secondPointer.Rotate(-Vector3.up * distToMoveSeconds, Space.Self);
                secondCounter = Time.time + 1;
            }


            if (Time.time > minuteCounter)
            {
                minutePointer.Rotate(-Vector3.up * distToMoveMinute,Space.Self);
                minuteCounter = Time.time + 60;
            }
        }

        if(Input.GetKeyDown("s"))
        {
            StartTimer();
        }
	}

    void StartTimer()
    {
        minuteCounter = Time.time + 60;
        secondCounter = Time.time + 1;

        isStarted = true;
    }

    void StopTimer()
    {
        isStarted = false;
    }
}
