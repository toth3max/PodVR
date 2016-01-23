using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadInput : MonoBehaviour {

    private float horizontalTouchpad;
    private float verticalTouchpad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var state = new VRControllerState_t();

        horizontalTouchpad = state.rAxis[(int)EVRButtonId.k_EButton_SteamVR_Touchpad].x;
        verticalTouchpad = state.rAxis[(int)EVRButtonId.k_EButton_SteamVR_Touchpad].y;

        Debug.Log(horizontalTouchpad);
    }
}
