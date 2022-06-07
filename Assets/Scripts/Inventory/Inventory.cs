using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;       //ПО ВОЗМОЖНОСТИ ПЕРЕДЕЛАТЬ

    [SerializeField] private int _space = 20;

    [SerializeField] private List<ItemSO> _items = new List<ItemSO>();

    public List<ItemSO> Items { get => _items; }

    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback;
    public event Action onItemChangedCallback;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Найдено более одного экземпляра Inventory");
            return;
        }

        Instance = this;
    }

    public bool Add(ItemSO item)
    {
        if (!item.IsDefaultItem)
        {
            if (_items.Count >= _space)
            {
                Debug.Log("Недостаточно места!");
                return false;
            }

            _items.Add(item);

            onItemChangedCallback?.Invoke();
        }
        return true;
    }

    public void Remove (ItemSO item)
    {
        _items.Remove(item);
        onItemChangedCallback?.Invoke();
    }
}
