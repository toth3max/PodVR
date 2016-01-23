using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PizzaManager : MonoBehaviour {

    public GameObject pizzaHookPrefab;
    public PizzaWheel currentPizzaHook;
    public Pizza currentPizza;
    public float spawnTimer;
    public Animator recepie;
    public Renderer[] allRecepieItems;

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

        Invoke("UpdateRecepie", 0.25f);
    }


    void UpdateRecepie()
    {
        for (int iii = 0; iii < allRecepieItems.Length; iii++)
        {
           allRecepieItems[iii].enabled = false;
        }

        currentPizza = GameObject.FindObjectOfType<Pizza>();

        int nrOfMushRooms = 0;
        int nrOfTomatoes = 0;
        int nrOfOnions = 0;
        int nrOfBroccolies = 0;

        for(int i = 0; i < currentPizza.myIngredients.Count; i++)
        {
            if(currentPizza.myIngredients[i] == "Broccoli")
            {
                nrOfBroccolies++;
            }

            if (currentPizza.myIngredients[i] == "Tomato")
            {
                nrOfTomatoes++;
            }

            if (currentPizza.myIngredients[i] == "Onion")
            {
                nrOfOnions++;
            }

            if (currentPizza.myIngredients[i] == "Mushroom")
            {
                nrOfMushRooms++;
            }
        }

        Debug.Log("NROFMUSHROOMS: "+nrOfMushRooms);
        for (int i = 0; i < nrOfMushRooms; i++ )
        {
            for (int ii = 0; ii < allRecepieItems.Length; ii++ )
            {
                if (allRecepieItems[ii].name.Contains("Mushroom") && !allRecepieItems[ii].enabled)
                {
                    allRecepieItems[ii].enabled = true;
                    break;
                }
            }
        }

        Debug.Log("nrOfBroccolies: " + nrOfBroccolies);
        for (int i = 0; i < nrOfBroccolies; i++)
        {
            for (int ii = 0; ii < allRecepieItems.Length; ii++)
            {
                if (allRecepieItems[ii].name.Contains("Broccoli") && !allRecepieItems[ii].enabled)
                {
                    allRecepieItems[ii].enabled = true;
                    break;
                }
            }
        }

        Debug.Log("nrOfTomatoes: " + nrOfTomatoes);
        for (int i = 0; i < nrOfTomatoes; i++)
        {
            for (int ii = 0; ii < allRecepieItems.Length; ii++)
            {
                if (allRecepieItems[ii].name.Contains("Tomato") && !allRecepieItems[ii].enabled)
                {
                    allRecepieItems[ii].enabled = true;
                    break;
                }
            }
        }

        Debug.Log("nrOfOnions: " + nrOfOnions);
        for (int i = 0; i < nrOfOnions; i++)
        {
            for (int ii = 0; ii < allRecepieItems.Length; ii++)
            {
                if (allRecepieItems[ii].name.Contains("Onion") && !allRecepieItems[ii].enabled)
                {
                    allRecepieItems[ii].enabled = true;
                    break;
                }
            }
        }


        //recepie.SetTrigger("update");
    }

    public void RemoveItemFromList(string name)
    {

		Debug.Log ("REMOVE FROM LIST: "+name);
		for (int ii = 0; ii < allRecepieItems.Length; ii++)
        {
            if (allRecepieItems[ii].name.Contains(name) && allRecepieItems[ii].enabled)
            {
                allRecepieItems[ii].enabled = false;
                break;
            }
        }
    }
}
