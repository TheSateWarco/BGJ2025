using UnityEngine;

public class LookAround : MonoBehaviour {
    public float rotationSpeed = 50f; // Base speed of rotation
    private float multipliedSpeed = 2f; // Speed boost for edge zones

    void Update() {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        if (mouseY > screenHeight * 0.20f && mouseY < screenHeight * 0.85f) {
            if (mouseX < screenWidth * 0.10f) // Cursor near left edge (faster turn left)
            {
                transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime * multipliedSpeed);
            } else if (mouseX > screenWidth * 0.90f) // Cursor near right edge (faster turn right)
              {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * multipliedSpeed);
            } else if (mouseX < screenWidth * 0.25f) // Cursor in left quarter (normal turn left)
              {
                transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            } else if (mouseX > screenWidth * 0.75f) // Cursor in right quarter (normal turn right)
              {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
