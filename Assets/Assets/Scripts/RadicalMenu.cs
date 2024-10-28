using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    public GameObject[] panels;  // Panels representing inventory slots
    public List<GameObject> items; // List of items to assign to the panels
    public float radius = 100f;   // Radius of the circle

    private GameObject selectedItem = null; // The currently selected item for dragging
    private GameObject currentSelectedItem;

    void Start()
    {
        PositionPanels();
        AssignItemsToPanels();
    }

    // Arrange the panels in a circular layout
    void PositionPanels()
    {
        float angleStep = 360f / panels.Length;
        for (int i = 0; i < panels.Length; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 panelPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            panels[i].transform.localPosition = panelPosition;

            // Optional: Add button components to the panels for item selection
            Button button = panels[i].AddComponent<Button>();
            int index = i;
            button.onClick.AddListener(() => SelectItemFromPanel(index));
        }
    }

    // Assign items from the list to the inventory panels
    void AssignItemsToPanels()
    {
        for (int i = 0; i < panels.Length && i < items.Count; i++)
        {
            GameObject item = items[i];
            // Create an Image to represent the item in the panel
            Image itemImage = item.GetComponent<Image>();
            Image panelImage = panels[i].GetComponent<Image>();

            if (itemImage != null && panelImage != null)
            {
                panelImage.sprite = itemImage.sprite; // Display the item's sprite in the panel
                panelImage.enabled = true;
            }

            // Disable the item GameObject as it will be dragged later
            //item.SetActive(false);
        }
    }

    // Select an item from the clicked panel to be dragged
    void SelectItemFromPanel(int panelIndex)
    {
        if (panelIndex < items.Count)
        {
            GameManager.Instance.currentDress?.SetActive(false);
            selectedItem = items[panelIndex];
            selectedItem.SetActive(true); // Activate the item for dragging
            GameManager.Instance.currentDress = selectedItem;
            if (currentSelectedItem != selectedItem) {
                currentSelectedItem?.SetActive(false);
            }
            currentSelectedItem = selectedItem;
        }
        GameManager.Instance.dressName = string.Empty;
        GameManager.Instance.dressName = selectedItem.GetComponent<Dress>().name.ToString();
        GameManager.Instance.height = selectedItem.GetComponent<Dress>().height;
        GameManager.Instance.bust = selectedItem.GetComponent<Dress>().bust;
        GameManager.Instance.hip = selectedItem.GetComponent<Dress>().hips;
        GameManager.Instance.waist = selectedItem.GetComponent<Dress>().waist;
    }

    // Use the DragDrop script for dragging the selected item
    void Update()
    {
        if (selectedItem != null && Input.GetMouseButton(0)) // While the mouse button is held
        {
            /*// Drag the selected item
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(selectedItem.transform.position).z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            selectedItem.transform.position = worldPosition;*/
        }

        if (Input.GetMouseButtonUp(0)) // On mouse release
        {
            if (selectedItem != null)
            {
                RaycastHit hitInfo;
                var rayOrigin = Camera.main.transform.position;
                var rayDirection = selectedItem.transform.position - Camera.main.transform.position;

                if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
                {
                    if (hitInfo.transform.tag == "DropArea")
                    {
                        selectedItem.transform.position = hitInfo.transform.position; // Drop the item in the DropArea
                    }
                }

                selectedItem = null; // Reset selected item after placing it
            }
        }
    }
}
