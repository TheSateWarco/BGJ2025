using UnityEngine;
using System.Collections;


public class IntruderMovement : MonoBehaviour
{
    public string intruderName;
    public int movementLevel = 15; // Difficulty level (1-20)
    private float moveTimer = 5f;

    void Start() {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine() {
        while (true) {
            yield return new WaitForSeconds(moveTimer);

            int roll = Random.Range(1, 21); // Roll between 1-20
            if (roll <= movementLevel) {
                MoveToNewLocation();
            }
        }
    }

    void MoveToNewLocation() {
        int newLocation = Random.Range(0, 7); // Pick a random scene ID
        IntruderManager.Instance.UpdateMonsterLocation(intruderName, newLocation);
        Debug.Log($"{intruderName} moved to room {newLocation}");
    }
}