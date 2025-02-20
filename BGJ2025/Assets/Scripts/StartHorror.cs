using UnityEngine;

public class StartHorror : MonoBehaviour
{
    private IntruderMovement[] intruders;

    void Start()
    {
        intruders = Object.FindObjectsByType<IntruderMovement>(FindObjectsSortMode.None);

        if (intruders.Length == 0)
        {
            Debug.LogError("No IntruderMovement objects found in the scene!");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked on: " + gameObject.name);

        if (intruders.Length == 0)
        {
            Debug.LogError("intruderMovement list is empty!");
            return;
        }

        // Set horror to true for all intruders
        foreach (var intruder in intruders)
        {
            if (!intruder.horror)
            {
                intruder.horror = true;
                PlayerPrefs.SetInt("HorrorMode", 1); // Save state
                PlayerPrefs.Save();
                Debug.Log($"Horror mode activated for {intruder.name}!");
            }
        }
    }
}
