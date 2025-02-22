using UnityEngine;
using System;

public class ItemPickup : MonoBehaviour {
    public InventoryItem itemData;

    void Start() {
        if (itemData == null) {
            Debug.LogError("itemData is null! Make sure it is assigned properly.");
            return;
        }

        if (string.IsNullOrEmpty(itemData.itemID)) {
            Debug.Log("itemID is empty or null.");
        }
        if (string.IsNullOrEmpty(itemData.itemID)) {
            itemData.itemID = Guid.NewGuid().ToString(); //  Ensure unique ID at runtime
        }

        if (Inventory.collectedItemIDs.Contains(itemData.itemID)) {
            Destroy(gameObject); //  Prevent duplicate spawning
        }
    }

    void OnMouseDown() {
        Inventory.instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
