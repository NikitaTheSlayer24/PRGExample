using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _removeButton;

    private ItemSO _item;

    public void AddItem (ItemSO newItem)
    {
        _item = newItem;

        _icon.sprite = _item.Icon;
        _icon.enabled = true;
        Debug.Log(_removeButton.interactable);
        _removeButton.interactable = true;
        Debug.Log(_removeButton.interactable);

    }

    public void ClearSlot()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
        _removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(_item);
    }

    public void UseItem()
    {
        if (_item != null)
        {
            _item.Use();
        }
    }
}
