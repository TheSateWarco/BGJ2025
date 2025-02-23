using UnityEngine;
using UnityEngine.SceneManagement;

public class KeySpawn: MonoBehaviour {
    public GameObject itemPrefab; // Assign in Inspector
    [SerializeField] private int roomIndex;

    void OnMouseDown() {
        if (itemPrefab != null) {
            string prefabName = itemPrefab.name;
            Vector3 spawnPosition = ItemSpawnPoint.spawnPosition; // Use this as the spawn position

            //  Save item spawn data before switching scenes
            ItemSpawnManager.RegisterItem(prefabName, spawnPosition);

            // Load the new scene
            //SceneManager.LoadScene(roomIndex);
        } else {
            Debug.LogError("ItemPrefab not set on: " + gameObject.name);
        }
    }
}
