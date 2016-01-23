using UnityEngine;
using System.Collections;

public class PoseTrigger : MonoBehaviour {

    public string LeftTriggerTag, RightTriggerTag, HeadTriggerTag;
    public PoseManager m_PoseManager;
    public Color startColour;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag(LeftTriggerTag))
        {
            m_PoseManager.LeftTriggered = true;
        }
        else if (_collider.CompareTag(RightTriggerTag))
        {
            m_PoseManager.RightTriggered = true;
        }
        else if (_collider.CompareTag(HeadTriggerTag))
        {
            m_PoseManager.HeadTriggered = true;
        }

        SwitchMaterialColour();
    }

    void OnTriggerExit(Collider _collider)
    {
        if (_collider.CompareTag(LeftTriggerTag))
        {
            m_PoseManager.LeftTriggered = false;
        }
        else if (_collider.CompareTag(RightTriggerTag))
        {
            m_PoseManager.RightTriggered = false;
        }
        else if (_collider.CompareTag(HeadTriggerTag))
        {
            m_PoseManager.HeadTriggered = false;
        }

        ResetMaterialColour();
    }

    public void SwitchMaterialColour()
    {
        rend.material.SetColor("_Albedo", Color.green);
    }

    public void ResetMaterialColour()
    {
        rend.material.SetColor("_Albedo", startColour);
    }
}
