using UnityEngine;
using System.Collections;

public class IntruderMovement : MonoBehaviour
{
    public string intruderName;
    public int movementLevel = 15; // Difficulty level (1-20)
    private float moveTimer = 5f;
    public bool horror = false; // This remains true after being set

    void Start()
    {
        horror = PlayerPrefs.GetInt("HorrorMode", 0) == 1; // Load state
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTimer);

            int roll = Random.Range(1, 21); // Roll between 1-20
            Debug.Log($"intruder is moving  {horror}");

            if (roll <= movementLevel && horror)
            {
                MoveToNewLocation();
            }
        }
    }

    void MoveToNewLocation()
    {
        int newLocation = Random.Range(0, 7); // Pick a random scene ID
        IntruderManager.Instance.UpdateIntruderLocation(intruderName, newLocation);
        Debug.Log($"{intruderName} moved to room {newLocation}");
    }
}
