using UnityEngine;
using UnityEngine.UI;

public class FlashingRed : MonoBehaviour {
    public Image redImage;
    public float flashSpeed = 0.1f; // Speed of the flash

    public void StartFlash() {
        if (redImage == null)
            redImage = GetComponent<Image>();

        InvokeRepeating("ToggleVisibility", 0f, flashSpeed);
    }

    void ToggleVisibility() {
        redImage.enabled = !redImage.enabled; // Flash effect
    }
}
