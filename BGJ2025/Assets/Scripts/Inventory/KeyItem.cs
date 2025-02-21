using UnityEngine;

[CreateAssetMenu(fileName = "NewKey", menuName = "Inventory/Key")]
public class KeyItem : InventoryItem {
    public string doorID; // Unique ID of the door this key unlocks


public override void Use() {
        Debug.Log("Key " + doorID + " is being used!");

        Door[] doors = FindObjectsByType<Door>(FindObjectsSortMode.None);
        foreach (Door door in doors) {
            if (door.doorID == doorID) {
                if (!door.isLocked) {
                    Debug.Log("Door " + doorID + " is already unlocked!");
                    return;
                }

                door.Unlock();
                Debug.Log("Key used on door: " + doorID);
                return;
            }
        }

        Debug.Log("No matching door found for key: " + doorID);
    }

}
