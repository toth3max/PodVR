﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class DirectionMarker : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private Follower[] followers;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        followers = GameObject.FindObjectsOfType<Follower>();
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
            if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                Vector3 targetPosition = hit.point;
                targetPosition.y = 0;
                foreach (var follower in followers) {
                    follower.SetPlayerTarget(targetPosition);
                }
            }
        } else {
        }
    }
   
    public void UseHaptics(uint force)
    {
        ushort hapticForce = (ushort)force;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
    }
}
