using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour {
    public static Vector3 spawnPosition;

    void Awake() {
        spawnPosition = transform.position; // Save the position for spawning items
    }
}