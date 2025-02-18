using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    public TMP_Text uiText; // Assign in Inspector

    void Start()
    {
        uiText.text = ""; // Start with an empty text
    }

    void OnMouseEnter()
    {
        uiText.text = "You are hovering over " + gameObject.name;
    }

    void OnMouseExit()
    {
        uiText.text = ""; // Clear text when not hovering
    }
}