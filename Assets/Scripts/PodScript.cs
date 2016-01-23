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
        podAnimator.SetTrigger("open");
    }

    public void Close()
    {
        podAnimator.SetTrigger("close");
    }
}
