using UnityEngine;
using System.Collections;

public class SirenSpin : MonoBehaviour {
    public float sirenSpeed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0, sirenSpeed);
	}
}
