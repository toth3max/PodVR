using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class TrackerScript : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    public GameObject CarriedObject;
    public GameObject PrefabToSpawn;

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

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                var shelfTankObject = hit.collider.GetComponent<ShelfTank>();

                if (shelfTankObject != null) {
                    DestroyCarriedObject();

                    var carriedObject = GameObject.Instantiate(shelfTankObject.SelectionPrefab, shelfTankObject.transform.position, shelfTankObject.transform.rotation) as GameObject;
                    var selectionObject = carriedObject.GetComponent<SelectionTank>();
                    selectionObject.Attach = transform;

                    var direction = Vector3.forward;
                    var distance = Vector3.Distance(transform.position, selectionObject.transform.position);
                    selectionObject.Distance = direction * distance;
                    CarriedObject = carriedObject;
                    PrefabToSpawn = shelfTankObject.SpawningPrefab;
                }
            }
        } else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
            DestroyCarriedObject();
        }
    }

    public void DestroyCarriedObject()
    {
        if (CarriedObject != null) {
            GameObject.Destroy(CarriedObject);
            CarriedObject = null;
            PrefabToSpawn = null;
        }
    }

    public void UseHaptics(uint force)
    {
        ushort hapticForce = (ushort)force;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
    }
}
