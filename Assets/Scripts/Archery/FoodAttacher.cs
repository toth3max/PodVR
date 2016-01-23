using UnityEngine;
using System.Collections;

public class FoodAttacher : MonoBehaviour {

   

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Arrow>())
        {
            Arrow arrow = other.GetComponent<Arrow>();
            transform.parent = arrow.transform;

            if(other.GetComponent<PickableObject>())
            {
                Destroy(other.GetComponent<PickableObject>());
            }

            transform.localPosition = Vector3.zero;
        }


    }

}
