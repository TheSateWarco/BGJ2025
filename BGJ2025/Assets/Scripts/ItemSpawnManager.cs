using UnityEngine;
using System.Collections.Generic;

public class ItemSpawnManager : MonoBehaviour {
    public static ItemSpawnManager instance;

    // Stores item positions & prefab names
    private static List<ItemSpawnData> spawnedItems = new List<ItemSpawnData>();

    [System.Serializable]
    public class ItemSpawnData {
        public string prefabName;
        public Vector3 position;

        public ItemSpawnData(string name, Vector3 pos) {
            prefabName = name;
            position = pos;
        }
    }

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static void RegisterItem(string prefabName, Vector3 position) {
        spawnedItems.Add(new ItemSpawnData(prefabName, position));
    }

    public static void SpawnSavedItems(Vector3 defaultPosition) {
        foreach (ItemSpawnData data in spawnedItems) {
            GameObject prefab = Resources.Load<GameObject>("Items/" + data.prefabName);
            if (prefab != null) {
                Vector3 positionToSpawn = (data.position != Vector3.zero) ? data.position : defaultPosition;
                Instantiate(prefab, positionToSpawn, Quaternion.identity);
            }
        }
        spawnedItems.Clear(); // Prevent duplicate spawns
    }

}
