using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class UnlockDoor : MonoBehaviour {
    public string doorID; // Unique identifier for each door
    public bool isLocked = true;
    public GameObject door;
    [SerializeField] private Animator transition;
    public int newRoom;
    [SerializeField] private float transitionTime = 1f;

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
        UnlockDoor door = GetComponent<UnlockDoor>();

        if (door != null && door.isLocked) {
            Debug.Log(" The door is locked! Transition blocked. Door Locked Status: " + door.isLocked);
            return; //  STOP if locked
        }


        Debug.Log(" Door is unlocked! Transition allowed.");
        //  Your transition code runs only if unlocked
        StartCoroutine(LoadRoom(newRoom));
        GameObject inventoryCanvas = GameObject.Find("InventoryCanvas");
        if (inventoryCanvas != null) {
            inventoryCanvas.SetActive(false);
        }
    }



    IEnumerator LoadRoom(int roomIndex) {

        // play animation
        transition.SetTrigger("Start");
        // wait for aniumation"
        yield return new WaitForSeconds(transitionTime);
        // load scene
        SceneManager.LoadScene(roomIndex);
    }



public void Unlock() {
        if (!isLocked) return; // Stop if already unlocked

        isLocked = false;
        Debug.Log("Door Unlocked!");


        // OPTIONAL: Change the door color to indicate it's unlocked
        Renderer doorRenderer = GetComponent<Renderer>();
        if (doorRenderer != null) {
            doorRenderer.material.color = Color.green;  // Change door color to green

        }
    }
    public void OpenDoor() {
        Debug.Log("Key " + doorID + " is being used!");

        UnlockDoor[] doors = FindObjectsByType<UnlockDoor>(FindObjectsSortMode.None);
        foreach (UnlockDoor door in doors) {
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




