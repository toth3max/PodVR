using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class HandTracker : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    public SelectBox CurrentSelected;

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
            if (CurrentSelected != null) {
                CurrentSelected.LoadLevel();
            }
        }
    }

    public void UseHaptics(uint force)
    {
        ushort hapticForce = (ushort)force;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
    }
}
