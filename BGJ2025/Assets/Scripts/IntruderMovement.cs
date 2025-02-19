using UnityEngine;
using System.Collections;

public class IntruderMovement : MonoBehaviour {
    public string intruderName;
    public int movementLevel = 15;
    private float moveTimer = 5f;
    public bool horror = false;

    void Awake() {
        // Force horror mode off if it doesn't exist
        if (!PlayerPrefs.HasKey("HorrorMode")) {
            PlayerPrefs.SetInt("HorrorMode", 0);
            PlayerPrefs.Save();
        }

        // Correct way to load horror mode state
        horror = PlayerPrefs.GetInt("HorrorMode") == 1;
    }

    void Start() {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine() {
        while (true) {
            yield return new WaitForSeconds(moveTimer);
            int roll = Random.Range(1, 21);
            Debug.Log($"Intruder is moving. Horror mode: {horror}");

            if (roll <= movementLevel && horror) {
                MoveToNewLocation();
            }
        }
    }

    void MoveToNewLocation() {
        int newLocation = Random.Range(0, 7);
        IntruderManager.Instance.UpdateIntruderLocation(intruderName, newLocation);
        Debug.Log($"{intruderName} moved to room {newLocation}");
    }

    public void EnableHorrorMode() {
        horror = true;
        PlayerPrefs.SetInt("HorrorMode", 1);
        PlayerPrefs.Save();
        Debug.Log("Horror mode enabled!");
    }

    public void DisableHorrorMode() {
        horror = false;
        PlayerPrefs.SetInt("HorrorMode", 0);
        PlayerPrefs.Save();
        Debug.Log("Horror mode disabled!");
    }
}
