using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class DirectionMarker : MonoBehaviour
{
    public LineRenderer LineRenderer;
    private Ray ray;
    private RaycastHit hit;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void AquireDevice()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void FixedUpdate()
    {
        if (device == null) {
            AquireDevice();
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            LineRenderer.GetComponent<LineRenderer>().enabled = true;
        } else {
            LineRenderer.GetComponent<LineRenderer>().enabled = false;
        }
    }
   
    public void UseHaptics(uint force)
    {
        ushort hapticForce = (ushort)force;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
    }
}
