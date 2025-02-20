using UnityEngine;

public class HoverExit : MonoBehaviour {
    private HoverManager hoverManager;
    private ChangeRooms changeRooms;
    private IntruderMovement intruderMovement;
    private AudioSource audioSource;
    public AudioClip footSteps;

    void Start()
    {
        hoverManager = FindFirstObjectByType<HoverManager>();
        changeRooms = FindFirstObjectByType<ChangeRooms>();
        intruderMovement = FindFirstObjectByType<IntruderMovement>(); //  Assign IntruderMovement
        audioSource = GetComponent<AudioSource>();

        footSteps = Resources.Load<AudioClip>("Audio/footSteps");
        if (footSteps == null)
        {
            Debug.LogError("Failed to load AudioClip from Resources! Ensure 'Assets/Resources/Audio/footSteps.wav' exists.");
        }
        else
        {
            Debug.Log("AudioClip successfully loaded: " + footSteps.name);
        }
    }

    void OnMouseEnter()
    {
        hoverManager.ShowHoverText(transform, gameObject.name);

        if (intruderMovement == null || changeRooms == null)
        {
            Debug.LogError("intruderMovement or changeRooms is null! Cannot check occupiedRooms.");
            return;
        }

        if (intruderMovement.occupiedRooms.Contains(changeRooms.newRoom))
        {
            audioSource.PlayOneShot(footSteps);
            Debug.Log("Footsteps should be playing");
        }
    }

    void OnMouseExit() {
        hoverManager.HideHoverText();
    }
}