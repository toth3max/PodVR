using UnityEngine;
using System.Collections;

public class FollowerManager : Manager<FollowerManager> {

    public GameObject FollowerPrefab;
    public int SpawnAmount;

    public Vector2 LowerBounds;
    public Vector2 UpperBounds;

    public System.Random RandomGenerator;

	// Use this for initialization
	void Start ()
    {
        RandomGenerator = new System.Random(GetHashCode());

        for (int i = 0; i < SpawnAmount; i++) {
            GameObject.Instantiate(FollowerPrefab, GetRandomSpawnLocation(), Quaternion.identity);
        }
	}

    public float RandomFloat(float min, float max)
    {
        var result = RandomGenerator.NextDouble() * (max - min);
        result += min;
        return (float)result;
    }
    
    public Vector3 GetRandomSpawnLocation()
    {
        var x = RandomFloat(LowerBounds.x, UpperBounds.x);
        var z = RandomFloat(LowerBounds.y, UpperBounds.y);

        return new Vector3(x, 0.1f, z);
    }
}
