using UnityEngine;
using UnityEngine.SceneManagement;

public class IntruderCheck : MonoBehaviour {
    public int currentRoom;

    void Start() {
        currentRoom = SceneManager.GetActiveScene().buildIndex;
        CheckForIntruders();
    }

    void CheckForIntruders() {
        foreach (var intruder in IntruderManager.Instance.intruderLocations) {
            if (intruder.Value == currentRoom) {
                Debug.Log($"{intruder.Key} is in the same room! Game Over?");
                // Trigger jumpscare or event
            }
        }
    }
}
