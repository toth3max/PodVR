using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pizza : MonoBehaviour {

    public List<string> myIngredients;
    private PizzaManager pizzaManager;
    private bool movingToOven;
    private bool movingToCarton;

    public Vector3[] ovenPos;
    public Vector3[] ovenRot;
    public int currentOvenPos;

	// Use this for initialization
	void Start () 
    {
        myIngredients = new List<string>();
        pizzaManager = GameObject.FindObjectOfType<PizzaManager>();
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
				pizzaManager.RemoveItemFromList(myIngredients[index]);

                myIngredients.RemoveAt(index);
                Debug.Log("CORRECT!");

                if(myIngredients.Count <= 0)
                {
                    pizzaManager.currentPizzaHook.DropPizza();
                    pizzaManager.RemovePizzaNote();
                    Debug.Log("PIZZADONE");
                }
            }
            else
            {
                pizzaManager.currentPizzaHook.moveSpeed += 10;
                Debug.Log("INCORRECT!!");
            }


            foodAttacher.PlaySplashEffect(transform);

            if(foodAttacher.transform.parent != null)
                Destroy(foodAttacher.transform.parent.gameObject);
        }
    }


    void Update()
    {
        if (movingToOven)
        {
            MoveToOven();
        }

        //TestWinMove
        if (Input.GetKeyDown("l"))
        {
            pizzaManager.currentPizzaHook.DropPizza();
            pizzaManager.RemovePizzaNote();
            Debug.Log("PIZZADONE");

            transform.parent.GetComponent<Rigidbody>().isKinematic = true;

            currentOvenPos = 0;
            movingToOven = true;
        }
    }

    void MoveToOven()
    {
        transform.position = Vector3.MoveTowards(transform.position,ovenPos[currentOvenPos],20* Time.deltaTime);
        transform.localRotation = Quaternion.Euler(Vector3.Slerp(transform.localRotation.eulerAngles, ovenRot[currentOvenPos], 20 * Time.deltaTime));
        transform.localScale = Vector3.MoveTowards(transform.localScale,new Vector3(0.5f,0.5f,0.5f),3 * Time.deltaTime);
        if(Vector3.Distance(transform.position,ovenPos[currentOvenPos]) < 0.2f)
        {
            currentOvenPos++;
        }

        if(currentOvenPos >= ovenPos.Length)
        {
            movingToOven = false;
            Destroy(gameObject);
        }
    }

    void MoveToPizzaBox()
    {

    }
	

    void OnDrawGizmos()
    {
        for (int i = 0; i < ovenPos.Length; i++)
        {
            Gizmos.DrawWireSphere(ovenPos[i], 0.5f);
        }
    }
}
