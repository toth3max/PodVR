using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadInput : MonoBehaviour {

    public GameObject touchPad;
    private float horizontalTouchpad;
    private float verticalTouchpad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        Debug.Log(touchPad.transform.localPosition);
    }
}
