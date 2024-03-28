using UnityEngine;

public class InventorySlotController
{
    private readonly InventorySlotView _view;

    public InventorySlotController(IReadOnlyInventorySlot<Sprite, int> slot, InventorySlotView view)
    {
        _view = view;
        _view.Image.gameObject.SetActive(false);
        _view.TextAmount.gameObject.SetActive(false);
        
            
        slot.ItemChange += onSlotItemIconChange;
        slot.ItemNumberChange += onSlotItemAmountChanged;

        UpdateImageIfNeed(slot);
            
        view.Icon = slot.Item;
        view.Amount = slot.Amount;
    }

    private void onSlotItemIconChange(Sprite newIconSprite)
    {
        _view.Image.gameObject.SetActive(newIconSprite != null);
        _view.Icon = newIconSprite;
    }

    private void onSlotItemAmountChanged(int newAmount)
    {
        _view.TextAmount.gameObject.SetActive(newAmount > 1);
        
        _view.Amount = newAmount;
    }

    private void UpdateImageIfNeed(IReadOnlyInventorySlot<Sprite, int> slot)
    {
        var inventorySlot = (InventorySlot)slot;
        if (inventorySlot != null)
        {
            inventorySlot.ItemId = inventorySlot.ItemId;
        }
    }
}
