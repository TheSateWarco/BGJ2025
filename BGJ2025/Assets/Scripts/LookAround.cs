using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust speed of rotation

    void Update()
    {
        float screenWidth = Screen.width;
        float mouseX = Input.mousePosition.x;

        if (mouseX > screenWidth * 0.75f) // If cursor is on the right 25% of the screen
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (mouseX < screenWidth * 0.25f) // If cursor is on the left 25% of the screen
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
    }
}