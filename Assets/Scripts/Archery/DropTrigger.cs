using UnityEngine;
using System.Collections;

public class DropTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PizzaWheel>())
        {
            PizzaWheel pizzaWheel = other.GetComponent<PizzaWheel>();

            pizzaWheel.DropPizza();

        }
    }
}
