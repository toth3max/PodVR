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

    public SelectionTank CarriedSelectionTank;
    public Tank CarriedTank;
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
                var tank = hit.collider.GetComponent<Tank>();

                if (shelfTankObject != null) {
                    DestroyCarriedObject();

                    var carriedObject = GameObject.Instantiate(shelfTankObject.SelectionPrefab, shelfTankObject.transform.position, shelfTankObject.transform.rotation) as GameObject;
                    var selectionObject = carriedObject.GetComponent<SelectionTank>();
                    selectionObject.Attach = transform;

                    var direction = Vector3.forward;
                    var distance = Vector3.Distance(transform.position, selectionObject.transform.position);
                    selectionObject.Distance = direction * distance;
                    CarriedSelectionTank = selectionObject;
                    PrefabToSpawn = shelfTankObject.SpawningPrefab;
                } else if (tank != null) {
                    DestroyCarriedObject();
                    DropCarriedTank();

                    tank.PickUp(this);
                }
            }
        } else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
            if (CarriedSelectionTank != null) {
                var spawnedTank = GameObject.Instantiate(PrefabToSpawn, CarriedSelectionTank.transform.position, CarriedSelectionTank.transform.rotation) as GameObject;
                spawnedTank.GetComponent<Rigidbody>().velocity = new Vector3();
            }

            if (CarriedTank != null) {
                DropCarriedTank();
            }

            DestroyCarriedObject();
        }
    }

    public void DestroyCarriedObject()
    {
        if (CarriedSelectionTank != null) {
            GameObject.Destroy(CarriedSelectionTank.gameObject);
            CarriedSelectionTank = null;
            PrefabToSpawn = null;
        }
    }

    public void DropCarriedTank( )
    {
        if (CarriedTank != null) {
                CarriedTank.Drop();
                CarriedTank = null;
            }
    }

    public void UseHaptics(uint force)
    {
        ushort hapticForce = (ushort)force;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(hapticForce);
    }
}
