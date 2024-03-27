using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IListener
{
    [SerializeField] private ScreenView _screenView;
    private InventoryService _inventoryService;
    private ScreenController _screenController;

    [NotNull]private static string OWNER_1 = "Afecto";
    private string _currentOwnerId;
    
    public void Start()
    {
        AddAllListeners();
        _inventoryService = new InventoryService();

        var inventoryData = CreateInventory(OWNER_1, 2, 3);
        _inventoryService.RegisterInventory(inventoryData);

        _screenController = new ScreenController(_inventoryService, _screenView);
        _screenController.OpenInventory(OWNER_1);
        _currentOwnerId = OWNER_1;
    }

    public void AddAllListeners()
    {
        PickupManager.OnPickupItemByPlayer += OnAddNewItem;
    }

    public void RemoveAllListeners()
    {
        PickupManager.OnPickupItemByPlayer -= OnAddNewItem;
    }
    
    private void OnAddNewItem(GameObject obj)
    {
        var pickup = obj.GetComponent<PickupManager>();
        _inventoryService.AddItemsToInventory(OWNER_1, pickup.Name);
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
