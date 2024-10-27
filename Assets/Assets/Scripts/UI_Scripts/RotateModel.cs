using UnityEngine;
using UnityEngine.EventSystems;

public class RotateModel : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && !IsPointerOverUI())
        {
            RotateModelWithMouse();
        }
    }

    private void RotateModelWithMouse()
    {
        // Get the horizontal mouse movement
        float horizontalInput = Input.GetAxis("Mouse X");

        // Calculate the rotation amount based on the mouse movement and speed
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // Rotate the model around the Y-axis in world space
        transform.Rotate(Vector3.up, rotationAmount, Space.World);
    }

    private bool IsPointerOverUI()
    {
        // Check if the mouse pointer is over any UI element
        return EventSystem.current.IsPointerOverGameObject();
    }
}

