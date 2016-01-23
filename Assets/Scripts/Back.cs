using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Back : MonoBehaviour
{
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

        if (device.GetTouch(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            SceneManager.LoadScene("GameHub");
        }
    }
}
