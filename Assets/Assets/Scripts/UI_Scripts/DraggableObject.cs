using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public string deleteTag = "DeleteArea";

    // Static flag to ensure only one object is dragged at a time
    private static bool isDragging = false;
    private bool isThisObjectDragging = false;

    void OnMouseDown()
    {
        // Check if another object is being dragged
        if (isDragging) return;
        Debug.Log("dragging works");
        isDragging = true;
        isThisObjectDragging = true;
        offset = transform.position - MouseWorldPosition();
        GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        if (!isThisObjectDragging) return; // Only drag if this object started the drag
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (!isThisObjectDragging) return; // Ensure this object initiated the release action

        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.CompareTag(destinationTag))
            {
                transform.position = hitInfo.transform.position;
            }
            if (hitInfo.transform.CompareTag(deleteTag))
            {
                Destroy(gameObject);
            }
        }

        GetComponent<Collider>().enabled = true;
        isDragging = false; // Reset global dragging flag
        isThisObjectDragging = false; // Reset this object's dragging flag
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}

