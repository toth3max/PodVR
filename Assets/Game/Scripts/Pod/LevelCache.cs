using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class LevelCache
{
	public static Dictionary<string, RootObject> LevelMap;
	
	static LevelCache()
	{
		LevelMap = new Dictionary<string, RootObject>();
	}
	
	public static void AddLevel(string levelName, RootObject rootObject)
	{
        LevelMap[levelName] = rootObject;
	}
	
	public static RootObject GetLevel(string levelName)
	{
		if(LevelMap.ContainsKey(levelName)){
			return LevelMap[levelName];
		}else{
			return null;
		}
	}

    public static bool IsLoaded(string levelName)
    {
        if (LevelMap.ContainsKey(levelName)) {
            return true;
        } else {
            return false;
        }
    }
}
