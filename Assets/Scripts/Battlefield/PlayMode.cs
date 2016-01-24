using UnityEngine;
using System.Collections;

public class PlayMode : Manager<PlayMode>
{
    public GameModeEnum GameMode;

    void Start()
    {
        GameMode = GameModeEnum.SetupMode;
    }
}
