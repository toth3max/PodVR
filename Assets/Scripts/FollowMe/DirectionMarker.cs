using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class DirectionMarker : MonoBehaviour
{
    public GameObject Pointer;
    private Ray ray;
    private RaycastHit hit;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private Follower[] followers;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void AquireDevice()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    public void GetFollowers()
    {
        followers = GameObject.FindObjectsOfType<Follower>();
    }

    void FixedUpdate()
    {
        if (followers == null) {
            GetFollowers();
        }

        if (device == null) {
            AquireDevice();
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                Vector3 targetPosition = hit.point;
                targetPosition.y = 0;
                foreach (var follower in followers) {
                    if (follower != null) {
                        follower.SetPlayerTarget(targetPosition);
                    }
                }
            }

            Pointer.GetComponent<Renderer>().enabled = true;
        } else {
            Pointer.GetComponent<Renderer>().enabled = false;
        }
    }
   
    public void UseHaptics(uint force)
    {
        ushort hapticForce = (ushort)force;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
    }
}
