using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Image _spriteIcon;
    [SerializeField] private Text _textAmount;

    public static Action<string, int> OnClickSlotAction;
    public Sprite Icon
    {
        get => _spriteIcon.sprite;
        set => _spriteIcon.sprite = value;
    }

    public Image Image => _spriteIcon;
    
    public Text TextAmount  => _textAmount;
    
    public int Amount
    {
        get => Convert.ToInt32(_textAmount.text);
        set => _textAmount.text = value.ToString();
    }

    public void OnClickSlot()
    {
        var nameSkin = "";
        if (_spriteIcon.sprite)
        {
            nameSkin = Icon.name;
        }
        OnClickSlotAction?.Invoke(nameSkin, Amount);
    }
}