using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MouseMovement : MonoBehaviour
{
    public float MovementSpeed;
    public List<Follower> Followers;

    void Start()
    {
        Followers = GameObject.FindObjectsOfType<Follower>().ToList();
    }

	// Update is called once per frame
	void Update ()
    {
        var mouseDelta = new Vector3(Input.GetAxis("Mouse X"), 0,  Input.GetAxis("Mouse Y"));
        transform.position = transform.position + (mouseDelta * MovementSpeed);

        if (Input.GetMouseButton(0)) {
            foreach (var follower in Followers) {
            follower.SetPlayerTarget(transform.position);
            }
        }
	}
}
