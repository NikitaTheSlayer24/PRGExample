using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] private ItemSO _item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
       // Debug.Log("Picking up " + _item.name);
        bool wasPickedUp = Inventory.Instance.Add(_item);
        if (wasPickedUp) Destroy(gameObject);
    }
}
