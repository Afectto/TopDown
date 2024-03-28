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
        _inventoryService = new InventoryService();

        var inventoryData = CreateInventory(OWNER, 2, 3);
        _inventoryService.RegisterInventory(inventoryData);

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
        Debug.Log("ON CLEAR " + nameSlotItem + " " + amount);
        if (amount > 0)
        {
            _inventoryService.RemoveItems(OWNER, nameSlotItem, amount);
        }
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
    
    void Update()
    {
        
    }


    public void OnDestroy()
    {
        RemoveAllListeners();
    }

}
