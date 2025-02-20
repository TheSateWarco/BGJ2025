using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public List<InventoryItem> items = new List<InventoryItem>();
    public Transform slotParent; // Assign UI Grid Panel
    public GameObject slotPrefab; // Assign slot prefab

    public void AddItem(InventoryItem newItem) {
        items.Add(newItem);
        RefreshUI();
    }

    public void RemoveItem(InventoryItem item) {
        items.Remove(item);
        RefreshUI();
    }

    void RefreshUI() {
        foreach (Transform child in slotParent) {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in items) {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.GetComponentInChildren<UnityEngine.UI.Image>().sprite = item.itemIcon;
        }
    }
}
