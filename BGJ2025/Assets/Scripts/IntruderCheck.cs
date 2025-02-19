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
                GameObject parentObject = GameObject.Find(intruder.Key);
                if (parentObject == null) {
                    Debug.LogError($"Parent GameObject '{intruder.Key}' not found in the scene!");
                    continue;
                }

                // Find the child object named "Crush"
                Transform childTransform = parentObject.transform.Find("crush");
                if (childTransform == null) {
                    Debug.LogError($"Child GameObject 'crush' not found under parent '{intruder.Key}'!");
                    continue;
                }

                // Get the SpriteToggle component from the child
                SpriteToggle spriteToggle = childTransform.GetComponent<SpriteToggle>();
                if (spriteToggle == null) {
                    Debug.LogError($"SpriteToggle component is missing on the child 'Crush'!");
                    continue;
                }

                // Show the sprite
                spriteToggle.ShowSprite();
            }
        }
    }
}
