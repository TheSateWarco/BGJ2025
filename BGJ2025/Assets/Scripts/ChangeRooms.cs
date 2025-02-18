using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditorInternal;

public class ChangeRooms : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private int newRoom;
    [SerializeField] private float transitionTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start() {
        if (transition == null) {
            Debug.LogError("Animator is missing! Assign an Animator component.");
            return;
        }
    }
    void OnMouseDown() {
        Debug.Log("Clicked on: " + gameObject.name);
        StartCoroutine(LoadRoom(newRoom)); ;
    }



    IEnumerator LoadRoom(int roomIndex) {

        // play animation
        transition.SetTrigger("Start");
        // wait for aniumation"
        yield return new WaitForSeconds(transitionTime);
        // load scene
        SceneManager.LoadScene(roomIndex);
    }

}
