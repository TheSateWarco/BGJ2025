using UnityEngine;
using UnityEngine.UI;

public class UIHeldItem : MonoBehaviour {
    public Button itemButton;
    public string itemName;

    private void Start() {
        itemButton.onClick.AddListener(() => UseItem());
    }

    private void UseItem() {
        Debug.Log("Used " + itemName);
        // Implement item behavior
    }
}