using UnityEngine;
using System.Collections;

public class PlayerMouseAndKeyboardInput : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float LookSpeedX = 20f;
    public float LookSpeedY = 20f;

    private float RotationX;
    private float RotationY;

    public Transform CameraObject;

	// Use this for initialization
	void Start ()
    {
        if (CameraObject == null) {
            Debug.LogWarning("PlayerMouseAndKeyboardInput is missing the camera setup");
            return;
        }

        RotationY = transform.rotation.eulerAngles.y;
        RotationX = CameraObject.rotation.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ReadInput();
	}

    public void ReadInput()
    {
        // Read raotation
        var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        RotationY += mouseMovement.x * LookSpeedX * Time.deltaTime;
        RotationX += mouseMovement.y * LookSpeedY * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, RotationY, 0));

        if (CameraObject != null) {
            CameraObject.localRotation = Quaternion.Euler(new Vector3(RotationX, 0, 0));
        }

        // Read movement
        var currentMovement = new Vector3();

        if (Input.GetKey(KeyCode.W)) {
            currentMovement += transform.forward;
        }

        if (Input.GetKey(KeyCode.S)) {
            currentMovement += -transform.forward;
        }

        if (Input.GetKey(KeyCode.A)) {
            currentMovement += -transform.right;
        }

        if (Input.GetKey(KeyCode.D)) {
            currentMovement += transform.right;
        }

        currentMovement *= MovementSpeed * Time.deltaTime;

        transform.position += currentMovement;
    }
}
