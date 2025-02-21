using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public static Inventory instance;
    public List<InventoryItem> items = new List<InventoryItem>();
    public GameObject inventoryCanvas; // Reference to the UI Canvas
    public Transform slotParent; // Holds the slots in the UI
    public GameObject slotPrefab;
    public static HashSet<string> collectedItemIDs = new HashSet<string>(); // Track collected items
    public Image heldItemSlot; // Assign in Inspector

    private InventoryItem heldItem;

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

        if (slotParent == null) {
            Debug.LogError("Inventory: slotParent is NOT assigned in Inspector!");
        }
    }

    public void RefreshUI() {
        if (slotParent == null) {
            Debug.LogError("Inventory: slotParent is NULL!");
            return;
        }
        UpdateInventoryUI();
    }

    public void AddItem(InventoryItem newItem) {
        if (!collectedItemIDs.Contains(newItem.itemID)) {
            collectedItemIDs.Add(newItem.itemID);
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
        if (slotParent == null || slotPrefab == null) {
            Debug.LogError("Inventory: slotParent or slotPrefab is NOT assigned!");
            return;
        }

        // Clear existing slots
        foreach (Transform child in slotParent) {
            Destroy(child.gameObject);
        }

        // Add a slot for each item
        foreach (InventoryItem item in items) {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            Debug.Log("Created slot for: " + item.itemName);

            // Find and assign item icon
            Transform iconTransform = slot.transform.Find("ItemIcon");
            if (iconTransform == null) {
                Debug.LogError("Inventory: ItemIcon NOT found in SlotPrefab!");
                continue;
            }

            Image icon = iconTransform.GetComponent<Image>();
            if (icon != null) {
                icon.sprite = item.itemIcon;
            } else {
                Debug.LogError("Inventory: ItemIcon Image component is missing in SlotPrefab!");
            }

            // Ensure slot has a Button
            Button button = slot.GetComponentInChildren<Button>();
            if (button == null) {
                Debug.LogError("Slot is missing a Button component!");
                continue;
            }
            button.onClick.RemoveAllListeners();

            InventoryItem itemCopy = item; // Prevent lambda reference issues
            button.onClick.AddListener(() => HoldItem(itemCopy));

            Debug.Log("Added button for: " + item.itemName);
        }
    }

    public void HoldItem(InventoryItem item) {
        if (item == null) {
            Debug.LogError("HoldItem: item is NULL!");
            return;
        }

        if (heldItemSlot == null) {
            Debug.LogError("HoldItem: heldItemSlot is NOT assigned in Inspector!");
            return;
        }

        Debug.Log("Holding item: " + item.itemName);
        heldItem = item;
        heldItemSlot.sprite = item.itemIcon;
        heldItemSlot.color = Color.white; // Ensure visibility
    }

    public void UseHeldItem() {
        if (heldItem != null) {
            heldItem.Use();
            heldItem = null;
            if (heldItemSlot != null) {
                heldItemSlot.sprite = null;
                heldItemSlot.color = Color.clear; // Hide when empty
            }
        }
    }
}
