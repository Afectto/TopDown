
using System.IO;
using UnityEngine;

public class GameStateFileProvider : GameStateAbstractProvider
{
    protected override string KEY { get; set; } = "Assets/SaveFile.txt";
    
    public override void SaveGameState()
    {
        var json = JsonUtility.ToJson(GameState);
        File.WriteAllText(KEY, json);
    }

    public override void LoadGameState()
    {
        if (File.Exists(KEY))
        {
            string json = File.ReadAllText(KEY);
            GameState = JsonUtility.FromJson<GameStateData>(json);
        }
        else
        {
            GameState = InitFromSetting();
            SaveGameState();
        }
    }

    
}
