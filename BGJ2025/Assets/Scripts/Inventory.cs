using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {
    public static Inventory instance;
    public List<InventoryItem> items = new List<InventoryItem>();
    public GameObject inventoryCanvas; // Reference to the UI Canvas
    public Transform slotParent; // This should hold the slots in the UI
    public GameObject slotPrefab;
    public static HashSet<string> collectedItemIDs = new HashSet<string>(); // Persistent collected items

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (inventoryCanvas == null) {
                inventoryCanvas = GameObject.Find("InventoryCanvas");
            }

            if (inventoryCanvas != null) {
                DontDestroyOnLoad(inventoryCanvas);
            } else {
                Debug.LogError("InventoryCanvas NOT found! Make sure it's in the scene.");
            }

        } else {
            Destroy(gameObject);
        }
    }




    void Start() {
        if (inventoryCanvas == null) {
            GameObject existingCanvas = GameObject.Find("InventoryCanvas");

            if (existingCanvas == null) {
                Debug.LogError("InventoryCanvas is missing! Creating a new one.");
                inventoryCanvas = new GameObject("InventoryCanvas");
                inventoryCanvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                DontDestroyOnLoad(inventoryCanvas);
            } else {
                inventoryCanvas = existingCanvas;
                DontDestroyOnLoad(inventoryCanvas);
            }
        }
    }



    public void RefreshUI() {
        if (slotParent == null) return;
        UpdateInventoryUI();
    }
    public void AddItem(InventoryItem newItem) {
        if (!collectedItemIDs.Contains(newItem.itemID)) {
            collectedItemIDs.Add(newItem.itemID); //  Track unique item
            items.Add(newItem);
            UpdateInventoryUI();
        } else {
            Debug.Log("Item already collected: " + newItem.itemName);
        }
    }

    public static bool HasItemBeenCollected(string itemID) {
        return collectedItemIDs.Contains(itemID);
    }
    void UpdateInventoryUI() {
        if (slotParent == null || slotPrefab == null) return;

        // Clear existing slots
        foreach (Transform child in slotParent) {
            Destroy(child.gameObject);
        }

        // Add a slot for each unique item
        foreach (InventoryItem item in items) {
            GameObject slot = Instantiate(slotPrefab, slotParent);

            // Set item sprite
            Transform iconTransform = slot.transform.Find("ItemIcon");
            if (iconTransform != null) {
                Image icon = iconTransform.GetComponent<Image>();
                if (icon != null) {
                    icon.sprite = item.itemIcon;
                } else {
                    Debug.LogError("Inventory: ItemIcon Image component not found on SlotPrefab!");
                }
            } else {
                Debug.LogError("Inventory: 'ItemIcon' object not found in SlotPrefab!");
            }

            // Ensure no quantity display
            Transform quantityTransform = slot.transform.Find("QuantityText");
            if (quantityTransform != null) {
                TMPro.TextMeshProUGUI quantityText = quantityTransform.GetComponent<TMPro.TextMeshProUGUI>();
                if (quantityText != null) {
                    quantityText.text = ""; // Always empty since we don’t stack
                }
            }
        }
    }
}
