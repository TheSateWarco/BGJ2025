using UnityEngine;

public class StartHorror : MonoBehaviour
{
    private IntruderMovement intruderMovement;

    void Start()
    {
        intruderMovement = Object.FindFirstObjectByType<IntruderMovement>(); // Ensure it's assigned

        if (intruderMovement == null)
        {
            Debug.LogError("IntruderMovement script not found in the scene!");
        }
    }

    void OnMouseDown()
    {
        if (!intruderMovement.horror)
        {
            intruderMovement.horror = true;
            PlayerPrefs.SetInt("HorrorMode", 1); // Save state
            PlayerPrefs.Save();
        }
    }

}
