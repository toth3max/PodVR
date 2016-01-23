using UnityEngine;
using System.Collections;
using System.IO;
using Valve.VR;

public class InputScript : MonoBehaviour
{
    protected Vector3 hAxis;
    protected Vector3 vAxis;
    public Camera playerCamera;
    public float playerSpeed = 10f;

    void Update()
    {
        hAxis = new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z);
        vAxis = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);

        float amtToMoveH = SteamVR_Controller.Input(2).GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad).x * playerSpeed * Time.deltaTime;
        float amtToMoveV = SteamVR_Controller.Input(2).GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad).y * playerSpeed * Time.deltaTime;

        transform.Translate(hAxis * amtToMoveH);
        transform.Translate(vAxis * amtToMoveV);
    }
}