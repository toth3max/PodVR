using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PizzaManager : MonoBehaviour {

    public GameObject pizzaHookPrefab;
    public PizzaWheel currentPizzaHook;
    public float spawnTimer;

	// Use this for initialization
	void Start () 
    {
        spawnTimer = Time.time + 5;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time > spawnTimer && currentPizzaHook == null)
        {
            SpawnHook();
        }
	}

    void SpawnHook()
    {
        GameObject pizzaHookClone = GameObject.Instantiate(pizzaHookPrefab) as GameObject;
        PizzaWheel pizzaWheel = pizzaHookClone.GetComponent<PizzaWheel>();

        currentPizzaHook = pizzaWheel;
    }
}
