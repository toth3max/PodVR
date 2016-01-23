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

        //SteamVR_Controller.Input(2).GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
        Debug.Log(SteamVR_Controller.Input(2).GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad));
    }
}
