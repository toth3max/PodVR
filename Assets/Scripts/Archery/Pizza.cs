using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pizza : MonoBehaviour {

    public List<string> myIngredients;
    
	// Use this for initialization
	void Start () 
    {
        myIngredients = new List<string>();
        GenerateIngredients();
	}

    void GenerateIngredients()
    {
        string ingredient = "";
        int totalIngredientAmount = Random.Range(3,10);

        for (int i = 0; i < totalIngredientAmount; i++ )
        {

            int random = Random.Range(0, 4);


            switch(random)
            {
                case 0:

                    ingredient = "Mushroom";

                    break;

                case 1:

                    ingredient = "Tomato";

                    break;

                case 2:

                    ingredient = "Broccoli";

                    break;

                case 3:

                    ingredient = "Onion";

                    break;
            }

            myIngredients.Add(ingredient);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FoodAttacher>())
        {
            FoodAttacher foodAttacher = other.GetComponent<FoodAttacher>();
            int index = -1;

            for (int i = 0; i < myIngredients.Count; i++ )
            {
                if (myIngredients[i] == foodAttacher.foodID)
                {
                    index = i;
                    break;
                }
            }


            if(index != -1)
            {
                myIngredients.RemoveAt(index);
                Debug.Log("CORRECT!");
            }
        }

  }
	
}
