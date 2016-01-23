using UnityEngine;
using System.Collections;

public class PodScript : MonoBehaviour 
{
    private Animator podAnimator;

	void Start () 
    {
        podAnimator = gameObject.GetComponent<Animator>();
	}
	
    void Update()
    {
        //TEST POD
        if(Input.GetKeyDown("o"))
        {
            Open();
        }

        if (Input.GetKeyDown("p"))
        {
            Close();
        }
    }

    public void Open()
    {
        Debug.Log("o");
        podAnimator.SetTrigger("open");
    }

    public void Close()
    {
        Debug.Log("p");
        podAnimator.SetTrigger("close");
    }
}
