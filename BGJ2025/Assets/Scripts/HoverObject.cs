using UnityEngine;

public class HoverObject : MonoBehaviour {
    private HoverManager hoverManager;

    void Start() {
        hoverManager = FindFirstObjectByType<HoverManager>(); 
                                                              // Finds the UI manager
    }

    void OnMouseEnter() {
        hoverManager.ShowHoverText(transform, gameObject.name);
    }

    void OnMouseExit() {
        hoverManager.HideHoverText();
    }
}