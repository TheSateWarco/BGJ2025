using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Clock : MonoBehaviour
{
    private float timeRemaining = 5f;
    public bool timerIsRunning = false;
    [SerializeField] private Animator transition;
    public int newRoom;
    [SerializeField] private float transitionTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartTimer() {
        timerIsRunning = true;
    }

    void Update() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            } else {
                Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("ChangeRooms script status: " + this.enabled);
                
                Debug.Log("Clicked on: " + gameObject.name);
                StartCoroutine(LoadRoom(newRoom)); ;
            }



            
        }
        
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