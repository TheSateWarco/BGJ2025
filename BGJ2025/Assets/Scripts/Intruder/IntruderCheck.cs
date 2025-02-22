using UnityEngine;
using UnityEngine.SceneManagement;

public class IntruderCheck : MonoBehaviour {
    public int currentRoom;
    private AudioSource audioSource;
    public AudioClip scare; // The scare sound effect
    public AudioClip heartbeat;

    void Start() {
        currentRoom = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();

        // Load the sound file from Resources
        scare = Resources.Load<AudioClip>("Audio/scare");
        heartbeat = Resources.Load<AudioClip>("Audio/heartbeat");

        if (scare == null) {
            Debug.LogError("Failed to load AudioClip from Resources! Ensure 'Assets/Resources/Audio/scare.wav' exists.");
        } else {
            Debug.Log("AudioClip successfully loaded: " + scare.name);
        }

        CheckForIntruders();
    }

    void CheckForIntruders() {
        foreach (var intruder in IntruderManager.Instance.intruderLocations) {
            if (intruder.Value == currentRoom) {
                Debug.Log($"{intruder.Key} is in the same room! Game Over?");

                // Find the intruder GameObject
                GameObject intruderObject = GameObject.Find(intruder.Key);
                if (intruderObject == null) {
                    Debug.LogError($"Intruder '{intruder.Key}' not found!");
                    continue;
                }

                // Get and show the SpriteToggle component
                SpriteToggle spriteToggle = intruderObject.GetComponent<SpriteToggle>();
                if (spriteToggle == null) {
                    Debug.LogError($"SpriteToggle component is missing on '{intruder.Key}'!");
                    continue;
                }
                spriteToggle.ShowSprite();

                // Play scare sound
                if (audioSource != null && scare != null) {
                    audioSource.PlayOneShot(scare); 
                    audioSource.PlayOneShot(heartbeat);
                    Debug.Log("Scare sound playing!");
                } else {
                    Debug.LogError("AudioSource or AudioClip is missing!");
                }
            }
        }
    }
}
