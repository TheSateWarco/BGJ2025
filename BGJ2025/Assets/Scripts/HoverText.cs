using UnityEngine;
using TMPro;

public class HoverTextDisplay : MonoBehaviour {
    public TMP_Text hoverText; // Assign the UI text in the Inspector
    public Vector3 textOffset = new Vector3(0, 2, 0); // Adjust the text position

    void Start() {
        hoverText.gameObject.SetActive(false); // Hide text initially
    }

    void OnMouseEnter() {
        hoverText.text = "This is " + gameObject.name;
        hoverText.transform.position = Camera.main.WorldToScreenPoint(transform.position + textOffset);
        hoverText.gameObject.SetActive(true);
    }

    void OnMouseExit() {
        hoverText.gameObject.SetActive(false);
    }

    void Update() {
        if (hoverText.gameObject.activeSelf) {
            hoverText.transform.position = Camera.main.WorldToScreenPoint(transform.position + textOffset);
        }
    }
}