using UnityEngine;

public class SpriteToggle : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowSprite() {
        spriteRenderer.enabled = true; // Make it visible
    }

    public void HideSprite() {
        spriteRenderer.enabled = false; // Hide it
    }
}