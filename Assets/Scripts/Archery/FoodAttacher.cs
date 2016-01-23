using UnityEngine;
using System.Collections;

public class FoodAttacher : MonoBehaviour {

    public string foodID;
    public GameObject partPrefab;
    public GameObject particleEffect;

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


    public void PlaySplashEffect(Transform parent)
    {
       GameObject partClone = GameObject.Instantiate(partPrefab,transform.position,Quaternion.identity) as GameObject;
       partClone.transform.parent = parent;

       Destroy(GameObject.Instantiate(partPrefab,partClone.transform.position,Quaternion.identity),4);

    }
}
