using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

    public FoodAttacher myFoodAttacher;
    public string myFoodID;
    public GameObject foodPrefab;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FoodAttacher>())
        {
            myFoodAttacher = other.GetComponent<FoodAttacher>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FoodAttacher>())
        {
            FoodAttacher foodAttacher = other.GetComponent<FoodAttacher>();

			if (foodAttacher.foodID == myFoodID)
            {
                SpawnFood();
            }
        }
    }

    void SpawnFood()
    {
		GameObject food = GameObject.Instantiate(foodPrefab,transform.position,Quaternion.identity) as GameObject;
		food.name = myFoodID;
    }
}
