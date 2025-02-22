using UnityEngine;

public class Door : MonoBehaviour {
    public string doorID; // Unique identifier for each door
    public bool isLocked = true;
    public GameObject door;

    void Start() {
        if (door != null) {
                Debug.Log("ChangeRooms disabled at start for: " + door.name);
            
        }

            /*if (isLocked) {
                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;  // Disable collider so clicks don’t register
            }*/
        }
    


    void OnMouseDown() {
        Door door = GetComponent<Door>();

        if (door != null && door.isLocked) {
            Debug.Log(" The door is locked! Transition blocked. Door Locked Status: " + door.isLocked);
            return; //  STOP if locked
        }

        Debug.Log(" Door is unlocked! Transition allowed.");
        //  Your transition code runs only if unlocked
    }


    public void Unlock() {
        if (!isLocked) return; //  Stop if already unlocked

        isLocked = false;
        Debug.Log("Door Unlocked!");

        if (door != null) {
            if (door != null) {
                //Collider col = GetComponent<Collider>();
                //if (col != null) col.enabled = true;
            }
            }
        }
    }




