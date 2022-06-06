using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private ItemSO _item;

    public void AddItem (ItemSO newItem)
    {
        _item = newItem;

        _icon.sprite = _item.Icon;
        _icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
    }
}
