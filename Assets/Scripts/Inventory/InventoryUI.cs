using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform _itemsParent;

    private Inventory _inventory;
    private InventorySlot[] _slots;

    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.onItemChangedCallback += UpdateUI;

        _slots = _itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < _inventory.Items.Count)
            {
                _slots[i].AddItem(_inventory.Items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
