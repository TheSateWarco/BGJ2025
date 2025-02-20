using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    void Start() {
        Vector3 spawnPos = ItemSpawnPoint.spawnPosition; // Get the saved spawn point
        ItemSpawnManager.SpawnSavedItems(spawnPos); // Pass the position
    }
}