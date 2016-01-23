using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class SelectBox : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip SelectSound;
    public AudioClip AcceptSound;

    [HideInInspector]
    public string LevelToLoad;

	void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayOneShot(SelectSound);

        var hand = collider.GetComponent<Hand>();

        if (hand != null) {
            hand.AttachedTracker.GetComponent<HandTracker>().CurrentSelected = this;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var hand = collider.GetComponent<Hand>();

        if (hand != null) {
            if (hand.AttachedTracker.GetComponent<HandTracker>().CurrentSelected == this) {
                hand.AttachedTracker.GetComponent<HandTracker>().CurrentSelected = null;
            }
        }
    }

    void OnMouseEnter()
    {
        AudioSource.PlayOneShot(SelectSound);
    }

    void OnMouseDown()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        AudioSource.PlayOneShot(AcceptSound);
        SceneManager.LoadScene(LevelToLoad);
    }
}
