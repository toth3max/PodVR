using UnityEngine;
using System.Collections;

public class SelfDesctruct : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

	// Use this for initialization
	void Start ()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!ParticleSystem.IsAlive()) {
            GameObject.Destroy(gameObject);
        }
	}
}
