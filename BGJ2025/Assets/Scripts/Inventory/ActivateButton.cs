using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ActivateButton : MonoBehaviour {
    public GameObject buttonObject; // Assign the button in the Inspector
    private Button button;

    void Start() {
        button = buttonObject.GetComponent<Button>();
    }
    public void EnableButton() {
        buttonObject.SetActive(true); // Activates the button
        //.onClick.RemoveAllListeners(); // Remove old listeners
        //button.onClick.AddListener(OnButtonClick);
    }

    public void DisableButton() {
        buttonObject.SetActive(false); // Deactivates the button
    }

    void OnButtonClick() {
       
        Debug.Log("Button Press");
    }

}

