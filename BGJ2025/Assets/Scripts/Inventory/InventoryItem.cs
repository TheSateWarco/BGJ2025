using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewItem", menuName = "InventoryStuff/Item")]
public class InventoryItem : ScriptableObject {
    public string itemName;
    public Sprite itemIcon;

    [HideInInspector]
    public string itemID; // Unique ID

    void OnEnable() {
        // Generate a unique ID when the ScriptableObject is created
        if (string.IsNullOrEmpty(itemID)) {
            itemID = Guid.NewGuid().ToString(); // Creates a unique identifier
        }

    }

    public virtual void Use() {
        Debug.Log("Holding: " + itemName);

    }
}


