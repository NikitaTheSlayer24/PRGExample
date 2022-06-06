
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon = null;
    [SerializeField] private bool _isDefaultItem = false;

    public bool IsDefaultItem { get => _isDefaultItem; }
    public Sprite Icon { get => _icon; }

    public virtual void Use()
    {
        Debug.Log("Using " + _name);
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
}
