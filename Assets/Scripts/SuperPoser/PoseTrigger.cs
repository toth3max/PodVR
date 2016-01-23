using UnityEngine;
using System.Collections;

public class PoseTrigger : MonoBehaviour {

    public string LeftTriggerTag, RightTriggerTag, HeadTriggerTag;
    public PoseManager m_PoseManager;

	// Use this for initialization
	void Start () {
	
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
    }

    public void SwitchMaterialColour()
    {
        Material _mat = GetComponent<Material>();
        Color _col = Color.green;
        _mat.color = _col;
    }
}
