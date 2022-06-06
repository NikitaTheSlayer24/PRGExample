using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;       //�� ����������� ����������

    [SerializeField] private int _space = 20;

    [SerializeField] private List<ItemSO> _items = new List<ItemSO>();

    public List<ItemSO> Items { get => _items; }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("������� ����� ������ ���������� Inventory");
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
                Debug.Log("������������ �����!");
                return false;
            }

            _items.Add(item);

            if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove (ItemSO item)
    {
        _items.Remove(item);

        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }
}
