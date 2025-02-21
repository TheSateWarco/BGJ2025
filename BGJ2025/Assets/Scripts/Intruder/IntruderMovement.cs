using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntruderMovement : MonoBehaviour {
    public string intruderName;
    public int movementLevel = 15;
    private float moveTimer = 2f;
    public bool horror = false;

    void Awake() {
        if (!PlayerPrefs.HasKey("HorrorMode")) {
            PlayerPrefs.SetInt("HorrorMode", 0);
            PlayerPrefs.Save();
        }
        horror = PlayerPrefs.GetInt("HorrorMode") == 1;
    }

    void Start() {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine() {
        while (true) {
            yield return new WaitForSeconds(moveTimer);
            int roll = Random.Range(1, 21);
            Debug.Log($"Intruder {intruderName} is moving. Horror mode: {horror}");

            if (roll <= movementLevel && horror) {
                MoveToNewLocation();
            }
        }
    }

    void MoveToNewLocation() {
        HashSet<int> occupiedRooms = IntruderManager.Instance.GetOccupiedRooms(); // Get all occupied rooms

        int newLocation;
        int attempts = 10; // Prevent infinite loops

        do {
            newLocation = Random.Range(0, 6); // Pick a random room
            attempts--;
        } while (occupiedRooms.Contains(newLocation) && attempts > 0); // Ensure it's unoccupied

        // If no valid room was found after 10 tries, just stay in place
        if (attempts == 0) {
            Debug.LogWarning($"{intruderName} could not find an empty room!");
            return;
        }

        // Update the intruder's location
        IntruderManager.Instance.UpdateIntruderLocation(intruderName, newLocation);
        Debug.Log($"{intruderName} moved to room {newLocation}");
    }

    public void EnableHorrorMode() {
        horror = true;
        PlayerPrefs.SetInt("HorrorMode", 1);
        PlayerPrefs.Save();
        Debug.Log("Horror mode enabled!");
    }

    public void DisableHorrorMode() {
        horror = false;
        PlayerPrefs.SetInt("HorrorMode", 0);
        PlayerPrefs.Save();
        Debug.Log("Horror mode disabled!");
    }
}
