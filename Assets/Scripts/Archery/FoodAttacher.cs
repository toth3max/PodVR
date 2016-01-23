using UnityEngine;
using System.Collections;

public class FoodAttacher : MonoBehaviour {

    public string foodID;
    public GameObject partPrefab;
    public GameObject particleEffect;
	public bool hasBeenAttached;

    void OnTriggerEnter(Collider other)
    {
		if(other.GetComponent<Arrow>())
        {
            Arrow arrow = other.GetComponent<Arrow>();

			if (!arrow.GetComponentInChildren<FoodAttacher> ()) 
			{
				transform.parent = arrow.transform.GetChild (0).GetChild (0);
               
				Destroy (gameObject.GetComponent<PickableObject> ());

				transform.localPosition = Vector3.zero + Vector3.forward * 0.5f;
			}
        }
    }


    public void PlaySplashEffect(Transform parent)
    {
       GameObject partClone = GameObject.Instantiate(partPrefab,transform.position,Quaternion.identity) as GameObject;
       partClone.transform.parent = parent;
	   partClone.transform.localPosition = new Vector3 (partClone.transform.localPosition.x, 0.22f, partClone.transform.localPosition.z);
		Destroy(GameObject.Instantiate(particleEffect,partClone.transform.position,Quaternion.identity),4);

    }
}
