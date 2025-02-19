using UnityEngine;
using System.Collections.Generic;

public class IntruderManager : MonoBehaviour {
    public static IntruderManager Instance;
    public Dictionary<string, int> intruderLocations = new Dictionary<string, int>(); // Track where monsters are

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void UpdateMonsterLocation(string intruderName, int newRoom) {
        if (intruderLocations.ContainsKey(intruderName))
            intruderLocations[intruderName] = newRoom;
        else
            intruderLocations.Add(intruderName, newRoom);
    }

    public int GetIntruderLocation(string intruderName) {
        return intruderLocations.ContainsKey(intruderName) ? intruderLocations[intruderName] : 0;
    }
}