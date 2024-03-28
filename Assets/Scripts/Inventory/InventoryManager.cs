using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IListener
{
    [SerializeField] private ScreenView _screenView;
    private InventoryService _inventoryService;
    private ScreenController _screenController;

    [NotNull]private static string OWNER = "Afecto";
    private string _currentOwnerId;
    
    public void Start()
    {
        AddAllListeners();
        var gameStateProvider = new GameStateFileProvider();
        gameStateProvider.LoadGameState();
        
        _inventoryService = new InventoryService(gameStateProvider);
        var gameState = gameStateProvider.GameState;
        foreach (var inventoryData in gameState.Inventories)
        {
            _inventoryService.RegisterInventory(inventoryData);
        }
        
        _screenController = new ScreenController(_inventoryService, _screenView);
        _screenController.OpenInventory(OWNER);
        _currentOwnerId = OWNER;
    }

    public void AddAllListeners()
    {
        ClearSlotButton.OnNeedClearSlot += OnClearSlotItem;
        PickupManager.OnPickupItemByPlayer += OnAddNewItem;
    }

    public void RemoveAllListeners()
    {
        ClearSlotButton.OnNeedClearSlot -= OnClearSlotItem;
        PickupManager.OnPickupItemByPlayer -= OnAddNewItem;
    }
    
    private void OnAddNewItem(GameObject obj)
    {
        var pickup = obj.GetComponent<PickupManager>();
        _inventoryService.AddItemsToInventory(OWNER, pickup.Name);
    }

    private void OnClearSlotItem(string nameSlotItem, int amount)
    {
        if (amount > 0)
        {
            _inventoryService.RemoveItems(OWNER, nameSlotItem, amount);
        }
    }

    
    public void OnDestroy()
    {
        RemoveAllListeners();
    }

}
