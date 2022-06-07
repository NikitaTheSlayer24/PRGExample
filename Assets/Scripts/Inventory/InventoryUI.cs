using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private GameObject _inventoryUI;

    private InventorySlot[] slots;

    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.onItemChangedCallback += UpdateUI;

        slots = _itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
        }
    }

    private void UpdateUI()
    { 
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < _inventory.Items.Count)
            {
                slots[i].AddItem(_inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
