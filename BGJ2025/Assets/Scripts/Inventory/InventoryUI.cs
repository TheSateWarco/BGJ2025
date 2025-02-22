/*using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public static InventoryUI instance;
    public Button useItemButton;  // Assign in Inspector
    private Inventory inventory;  // Reference to inventory system

    void Awake() {
        instance = this;
        Inventory inventory = FindFirstObjectByType<Inventory>();  // Find inventory script
        useItemButton.gameObject.SetActive(false);  // Hide button at start
    }

    void Start() {
        useItemButton.gameObject.SetActive(false);
    }

        void Update() {
        if (inventory != null && inventory.heldItemSlot != null) {
            useItemButton.gameObject.SetActive(true);  // Show button if item is held
        } else {
            useItemButton.gameObject.SetActive(false); // Hide button when no item is held
        }
    }

    public void UseHeldItem() {
        if (inventory.heldItemSlot != null) {
            inventory.heldItemSlot.Use();  // Use the held item
            inventory.heldItemSlot = null;  // Clear the held item after use
            useItemButton.gameObject.SetActive(false);  // Hide button
        }
    }
}
*/