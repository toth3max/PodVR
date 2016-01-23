using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class PodLoadingScript : MonoBehaviour
{
    public GameObject PlayerRigPrefab;

    private Scene SceneStartingScene;
    private int CurrenSceneIndex;
    private Scene? currentScene;
    private bool IsLoading;

	// Use this for initialization
	void Start ()
	{

        SceneStartingScene = SceneManager.GetActiveScene();
        if (LevelCache.IsLoaded(SceneStartingScene.name)){
            return;
        } else {
            LevelCache.CurrentRootObject = SceneStartingScene.name;
        }

        DontDestroyOnLoad(gameObject);
        currentScene = SceneStartingScene;
		IsLoading = true;
	}
	
	public void Loading()
	{
        try {
            if (currentScene.Value.isLoaded) {
                var rootObject = CreateRoomObject(currentScene.Value.name);
                AddLevelToCache(currentScene.Value, rootObject);
                CurrenSceneIndex++;
                SceneManager.LoadScene(CurrenSceneIndex, LoadSceneMode.Additive);
                currentScene = SceneManager.GetSceneAt(CurrenSceneIndex);
            }
        } catch (IndexOutOfRangeException) {
            Debug.Log("Out of range exit");
            LevelCache.LevelMap[SceneStartingScene.name].gameObject.SetActive(true);
            IsLoading = false;
        }
	}

    public RootObject CreateRoomObject(String roomName)
    {
        GameObject parentObject = new GameObject(roomName);
        var result = parentObject.AddComponent<RootObject>();
        foreach (var gameObject in GameObject.FindObjectsOfType<Transform>()) {
            if (gameObject.GetComponent<RootObject>() == null && gameObject.transform.parent == null && gameObject.GetComponent<SteamVR_ControllerManager>() == null && gameObject.GetComponent<PodLoadingScript>() == null && gameObject.GetComponent<SteamVR>() == null) {
                gameObject.parent = parentObject.transform;
            }
        }

        parentObject.SetActive(false);
        return result;
    }

    public void AddLevelToCache(Scene scene, RootObject rootObject)
    {
        Debug.Log("Added " + scene.name);
        var sceneName = scene.name;
        LevelCache.AddLevel(sceneName, rootObject);
    }
	
	
	// Update is called once per frame
	void Update ()
    {
	    if(IsLoading){
            Loading();
        }
	}
}
