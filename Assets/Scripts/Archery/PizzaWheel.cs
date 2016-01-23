using UnityEngine;
using System.Collections;

public class PizzaWheel : MonoBehaviour {

    public Vector3 pizzaStartPos;
    public GameObject pizzaPrefab;
    private Transform currentPizza;
        
    private Transform wheel;
    public float speed;
    public float moveSpeed;
    public HingeJoint hookJoint;
    private Animator hookAnimator;
    public bool isMoving;

    float randomTimer;

	void Start () 
    {
        
        wheel = transform.FindChild("Wheel");
        hookJoint = gameObject.GetComponentInChildren<HingeJoint>();
        hookAnimator = hookJoint.GetComponent<Animator>();
        moveSpeed = Random.Range(1,3);

        SpawnPizza();
        isMoving = true;
	}
	
    void SpawnPizza()
    {
        GameObject pizzaClone = GameObject.Instantiate(pizzaPrefab) as GameObject;

        pizzaClone.transform.parent = hookJoint.transform;
        pizzaClone.transform.localPosition = Vector3.zero;

        currentPizza = pizzaClone.transform;

        randomTimer = Time.time + Random.Range(0.5f, 3);
    }

	void Update () 
    {
        if(isMoving)
        {
            Move();
            RotateWheel();
        }

        if(Time.time > randomTimer)
        {
            if(isMoving)
            {
                hookAnimator.SetTrigger("wobble");
				moveSpeed = Random.Range(1,3);
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }

            randomTimer = randomTimer = Time.time + Random.Range(0.5f, 3);
        }

	    if(Input.GetKeyDown("d"))
        {
            DropPizza();
        }
	}

    void Move()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void RotateWheel()
    {
        wheel.transform.Rotate(Vector3.up * speed * Time.deltaTime,Space.Self);
    }

    public void DropPizza()
    {
        currentPizza.parent = null;
        currentPizza.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        currentPizza.gameObject.GetComponent<Rigidbody>().useGravity = true;

		Destroy (gameObject, 2);
    }
}
