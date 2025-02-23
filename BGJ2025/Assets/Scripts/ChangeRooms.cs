using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif

using UnityEngine.Audio;

public class ChangeRooms : MonoBehaviour
{
    [SerializeField] private Animator transition;
    public int newRoom;
    [SerializeField] private float transitionTime = 1f;
    public AudioClip doorSqueak;
    private AudioSource audioSource;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start() {
        if (transition == null) {
            Debug.LogError("Animator is missing! Assign an Animator component.");
            return;
        }
        audioSource = GetComponent<AudioSource>();
        doorSqueak = Resources.Load<AudioClip>("Audio/doorSqueak");
        

    }
    void OnMouseDown() {
        Debug.Log("ChangeRooms script status: " + this.enabled);
        if (gameObject.tag == "Door") {
            audioSource.PlayOneShot(doorSqueak);
        }
        Debug.Log("Clicked on: " + gameObject.name);
        StartCoroutine(LoadRoom(newRoom)); 
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
