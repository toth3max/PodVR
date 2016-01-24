using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(Target))]
public class TargetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var currentTarget = (Target)target;
        currentTarget.LevelToLoad = ScenePopup("Level to load", currentTarget.LevelToLoad);
        EditorUtility.SetDirty(target);
    }

    public string ScenePopup(string label, string current)
    {
        var sceneNames = new List<string>();
        foreach (var scene in EditorBuildSettings.scenes) {
            if (scene.enabled) {
                sceneNames.Add(GetSceneName(scene.path));
            }
        }

        int selectedScene = EditorGUILayout.Popup(label, GetIndex(sceneNames, current), sceneNames.ToArray());
        return sceneNames[selectedScene];
    }

    private string GetSceneName(string scenePath)
    {
        return scenePath.Split('/').Last().Replace(".unity", "");
    }

    private int GetIndex(List<string> names, string current)
    {
        if (current == "") {
            return 0;
        }

        for (int i = 0; i < names.Count; i++) {
            if (names[i] == current) {
                return i;
            }
        }
        return 0;
    }
}
