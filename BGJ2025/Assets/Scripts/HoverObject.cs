using UnityEngine;
using TMPro;

public class HoverObject : MonoBehaviour {
    private HoverManager hoverManager;
    [SerializeField] private string text;
    private TextMeshProUGUI uiText;

    void Start() {
        hoverManager = FindFirstObjectByType<HoverManager>();
        GameObject textBox = GameObject.Find("TextBox");
       
        uiText = textBox.GetComponentInChildren<TextMeshProUGUI>();  // Find text in the scene
        if (uiText == null) {
            Debug.LogError("BottomText UI element not found in the scene!");
        }
        uiText.text = "";
        if (uiText == null) {
            Debug.LogError("TextMeshProUGUI not found! Make sure it's inside 'BottomTextImage'.");
        }
    }

    void OnMouseEnter() {
        hoverManager.ShowHoverText(transform, gameObject.name);
    }

    void OnMouseExit() {
        hoverManager.HideHoverText();
    }

    void OnMouseDown() {
        uiText.text = text;
    }
}