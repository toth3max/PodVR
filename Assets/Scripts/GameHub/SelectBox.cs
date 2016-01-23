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
        //SceneManager.LoadScene(LevelToLoad);
    }
}
