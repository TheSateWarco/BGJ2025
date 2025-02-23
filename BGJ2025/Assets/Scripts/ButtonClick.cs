using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour


{

    [SerializeField] private Button button;
    [SerializeField] private Animator transition;
    [SerializeField] private int newRoom;
    [SerializeField] private float transitionTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (button != null)
            button.onClick.AddListener(changeScene);
    }

    void changeScene() {
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
