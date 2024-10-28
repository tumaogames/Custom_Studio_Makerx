using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropParent : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public string deleteTag = "DeleteArea";

    // Static flag to allow only one drag at a time
    private static bool isDragging = false;
    public Transform selectedObject = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isDragging) return; // Ignore new drag requests if already dragging another object

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.IsChildOf(transform)) // Check if the clicked object is a child of this parent
                {
                    selectedObject = hit.transform;
                    offset = selectedObject.position - MouseWorldPosition();
                    selectedObject.GetComponent<Collider>().enabled = false;
                    isDragging = true;
                }
            }
        }

        if (Input.GetMouseButton(0) && selectedObject != null)
        {
            // Move the selected object to follow the mouse
            selectedObject.position = MouseWorldPosition() + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            // Release the selected object
            var rayOrigin = Camera.main.transform.position;
            var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
            {
                if (hitInfo.transform.CompareTag(destinationTag))
                {
                    selectedObject.position = hitInfo.transform.position;
                }
                else if (hitInfo.transform.CompareTag(deleteTag))
                {
                    Destroy(selectedObject.gameObject);
                }
            }

            selectedObject.GetComponent<Collider>().enabled = true;
            selectedObject = null;
            isDragging = false; // Allow other objects to be dragged
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
