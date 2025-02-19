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

                // Find the parent object by name
                GameObject intruderObject = GameObject.Find(intruder.Key);

                // Get the SpriteToggle component from the child
                SpriteToggle spriteToggle = intruderObject.GetComponent<SpriteToggle>();
                if (spriteToggle == null) {
                    Debug.LogError($"SpriteToggle component is missing on the 'Crush'!");
                    continue;
                }

                // Show the sprite
                spriteToggle.ShowSprite();
            }
        }
    }
}
