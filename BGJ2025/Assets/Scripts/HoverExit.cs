using UnityEngine;

public class HoverExit : MonoBehaviour {
    private HoverManager hoverManager;
    private ChangeRooms changeRooms;
    private AudioSource audioSource;
    public AudioClip footSteps;

    void Start() {
        hoverManager = FindFirstObjectByType<HoverManager>();
        changeRooms = FindFirstObjectByType<ChangeRooms>();
        audioSource = GetComponent<AudioSource>();

        footSteps = Resources.Load<AudioClip>("Audio/footSteps");
        if (footSteps == null) {
            Debug.LogError("Failed to load AudioClip from Resources! Ensure 'Assets/Resources/Audio/footSteps.wav' exists.");
        } else {
            Debug.Log("AudioClip successfully loaded: " + footSteps.name);
        }
    }

    void OnMouseEnter() {
        hoverManager.ShowHoverText(transform, gameObject.name);

        if (changeRooms == null) {
            Debug.LogError("ChangeRooms is null! Cannot check occupiedRooms.");
            return;
        }

        // Get occupied rooms from IntruderManager
        if (IntruderManager.Instance.GetOccupiedRooms().Contains(changeRooms.newRoom)) {
            if (audioSource != null && footSteps != null) {
                audioSource.PlayOneShot(footSteps);
                Debug.Log("Footsteps should be playing");
            } else {
                Debug.LogError("AudioSource or footSteps clip is missing!");
            }
        }
    }

    void OnMouseExit() {
        hoverManager.HideHoverText();
    }
}
