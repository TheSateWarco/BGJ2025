using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public InventoryItem item; // Reference to the ScriptableObject item

    private void OnTriggerEnter(Collider other) // For 3D
    {
        if (other.CompareTag("Player")) {
            Inventory inventory = Object.FindFirstObjectByType<Inventory>(); // Find inventory
            if (inventory != null) {
                inventory.AddItem(item);
                Destroy(gameObject); // Remove the item from the scene
            }
        }
    }
}
