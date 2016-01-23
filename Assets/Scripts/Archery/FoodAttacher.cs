using UnityEngine;
using System.Collections;

public class FoodAttacher : MonoBehaviour {

    public string foodID;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Arrow>())
        {
            Arrow arrow = other.GetComponent<Arrow>();
            transform.parent = arrow.transform;
               
            Destroy(gameObject.GetComponent<PickableObject>());

            transform.localPosition = Vector3.zero;
        }
    }

}
