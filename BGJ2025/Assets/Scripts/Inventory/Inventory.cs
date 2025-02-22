using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour {
    public static Inventory instance;
    public List<InventoryItem> items = new List<InventoryItem>();
    public GameObject inventoryCanvas; // Reference to the UI Canvas
    public Transform slotParent; // Holds the slots in the UI
    public GameObject slotPrefab;
    public static HashSet<string> collectedItemIDs = new HashSet<string>(); // Track collected items
    public UnityEngine.UI.Image heldItemSlot; // Assign in Inspector
    public UnityEngine.UI.Button buttonObject;
    public KeyItem keyScript;
    public ActivateButton activateButton;

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
            if (buttonObject == null) {
                buttonObject = GameObject.Find("YourButtonName")?.GetComponent<UnityEngine.UI.Button>();
                if (buttonObject == null) {
                    Debug.LogError("Button Object NOT found in the scene!");

                }

            }
        } else {
            Destroy(gameObject);
        }


    }


    void Start() {

        buttonObject.gameObject.SetActive(false);
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
        if (slotParent == null) {
            GameObject foundParent = GameObject.Find("SlotParent");
            if (foundParent != null) {
                slotParent = foundParent.transform;
                Debug.Log("slotParent found: " + slotParent.name);
            } else {
                Debug.LogError("slotParent NOT found in the scene!");
            }
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
        Debug.Log("slotParent after UpdateInventoryUI: " + (slotParent != null ? slotParent.name : "NULL"));
    }

    public static bool HasItemBeenCollected(string itemID) {
        return collectedItemIDs.Contains(itemID);
    }

    void UpdateInventoryUI() {
        if (slotParent == null) {
            Debug.LogError("Inventory: slotParent is NULL when updating inventory! Assign it in the Inspector.");
            return;
        }

        Debug.Log("Updating inventory UI. slotParent is: " + slotParent.name);
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

            UnityEngine.UI.Image icon = iconTransform.GetComponent<UnityEngine.UI.Image>();
            if (icon != null) {
                icon.sprite = item.itemIcon;
            } else {
                Debug.LogError("Inventory: ItemIcon Image component is missing in SlotPrefab!");
            }

            // Ensure slot has a Button
            UnityEngine.UI.Button button = slot.GetComponentInChildren<UnityEngine.UI.Button>();
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

        buttonObject.onClick.Invoke(); // Test if the button works programmatically
        buttonObject.gameObject.SetActive(true); // Ensure the button is visible
        buttonObject.interactable = true;
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


        buttonObject.onClick.RemoveAllListeners(); // Ensure no duplicate listeners

        //buttonObject.onClick.RemoveAllListeners(); // Clear old actions

        buttonObject.onClick.AddListener(() => Debug.Log("Block used!"));
        // Assign a new action based on the item
        switch (item.itemName) {
            case "testKey":
                Debug.Log("Adding OpenDoor to button!");
                buttonObject.onClick.AddListener(OpenDoor);
                break;
            case "block":
                Debug.Log("Adding Block Action to button!");
                buttonObject.onClick.AddListener(() => Debug.Log("Block used!"));
                break;
        }
    
}

    private void OpenDoor() {
        Debug.Log("You Opened Front Door");
    }
}
