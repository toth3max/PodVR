using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System;
using System.Linq;

[CustomEditor(typeof(Pod))]
public class PodEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var currentTarget = (Pod)target;
        var sceneNames = new List<string>();
        foreach (var scene in EditorBuildSettings.scenes) {
            if (scene.enabled) {
                sceneNames.Add(GetSceneName(scene.path));
            }
        }

        currentTarget.PodNumber = (PodEnum)EditorGUILayout.EnumPopup("Pod Number",  currentTarget.PodNumber);
        EditorGUILayout.Separator();

        int selectedScene = EditorGUILayout.Popup("Level to Load", GetIndex(sceneNames, currentTarget.LevelToLoad), sceneNames.ToArray());
        currentTarget.LevelToLoad = sceneNames[selectedScene];
        currentTarget.MatchingPodNumber = (PodEnum)EditorGUILayout.EnumPopup("Mathing Pod Number", currentTarget.MatchingPodNumber);

        EditorUtility.SetDirty(currentTarget);
    }

    private string GetSceneName(string scenePath)
    {
        return scenePath.Split('/').Last().Replace(".unity", "");
    }

    private int GetIndex(List<string> names, string current)
    {
        if(current == ""){
            return 0;
        }

        for(int i = 0; i < names.Count; i ++){
            if(names[i] == current){
                return i;
            }
        }
        return 0;
    }
}
