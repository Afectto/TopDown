using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClearSlotButton : MonoBehaviour, IListener, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button button;

    private bool _isClickOnSlot;
    private bool _isOverlapButton;
    private string _nameSlotItem;
    private int _amountInSlotItem;

    public static Action<string, int> OnNeedClearSlot;
    
    public void Start()
    {
        AddAllListeners();
        gameObject.SetActive(false);
        _isClickOnSlot = false;
        _isOverlapButton = false;
    }

    public void AddAllListeners()
    {
        button.onClick.AddListener(OnClickClearButton);
        InventorySlotView.OnClickSlotAction += OnClickSlot;
    }

    public void RemoveAllListeners()
    {
        button.onClick.RemoveListener(OnClickClearButton);
        InventorySlotView.OnClickSlotAction -= OnClickSlot;
    }
    
    private void OnClickClearButton()
    {
        OnNeedClearSlot?.Invoke(_nameSlotItem, _amountInSlotItem);
        gameObject.SetActive(false);
    }

    private void OnClickSlot(string nameSlotItem, int amount)
    {
        _isClickOnSlot = true;
        
        gameObject.SetActive(true);
        var mousePosition = Input.mousePosition;
        transform.position = Utils.GetMouseWorldPosition(mousePosition);
        _nameSlotItem = nameSlotItem;
        _amountInSlotItem = amount;
        
        _isClickOnSlot = false;
    }

    private void Update()
    {
        if (!_isClickOnSlot && !_isOverlapButton && Input.GetMouseButton(0))
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isOverlapButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isOverlapButton = false;
    }
    
    public void OnDestroy()
    {
        RemoveAllListeners();
    }

}
