using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateAbstractProvider : IGameStateProvider, IGameStateSaver
{
    protected virtual string KEY { get; set; } = "";
    
    public GameStateData GameState { get; protected set; }

    public abstract void SaveGameState();
    public abstract void LoadGameState();

    protected GameStateData InitFromSetting()
    {
        var gameState = new GameStateData
        {
            Inventories = new List<InventoryGridData>
            {
                CreateInventory("Afecto", 2 , 3)
            }
        };
        return gameState;
    }
    
    private InventoryGridData CreateInventory(string ownerId, int sizeX, int sizeY)
    {
        var size = new Vector2Int(sizeX, sizeY);
        var createdInventorySlots = new List<InventorySlotData>();
        var length = sizeX + sizeY + 1;

        for (int i = 0; i < length; i++)
        {
            createdInventorySlots.Add(new InventorySlotData());
        }
        var createInventoryData = new InventoryGridData
        {
            OwnerID = ownerId,
            Size = size,
            SlotsData = createdInventorySlots
        };
        return createInventoryData;
    }
}
