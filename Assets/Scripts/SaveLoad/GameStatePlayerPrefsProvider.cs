using System.Collections.Generic;
using UnityEngine;

public class GameStatePlayerPrefsProvider : GameStateAbstractProvider
{
    protected override string KEY { get; set; } = "GAME STATE";
    
    public override void SaveGameState()
    {
        var json = JsonUtility.ToJson(GameState);
        PlayerPrefs.SetString(KEY, json);
    }

    public override  void LoadGameState()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            var json = PlayerPrefs.GetString(KEY);
            GameState = JsonUtility.FromJson<GameStateData>(json);
        }
        else
        {
            GameState = InitFromSetting();
            SaveGameState();
        }
    }

}