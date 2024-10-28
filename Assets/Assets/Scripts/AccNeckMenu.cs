using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccNeckMenu : MonoBehaviour
{
    public GameObject[] panels;  // Panels representing inventory slots
    public List<GameObject> items;  // List of items to assign to the panels
    public int columns = 2;      // Number of columns for the grid layout
    public float spacing = 100f; // Spacing between panels
    public Transform spawnArea;  // The area where spawned items will appear
    public int maxSpawnCount = 10; // Max number of items to spawn per panel

    private int[] itemSpawnCount; // Array to track how many times an item is spawned

    void Start()
    {
        itemSpawnCount = new int[panels.Length]; // Initialize the spawn count array
        PositionPanelsInGrid();
        AssignItemsToPanels();
    }

    // Arrange the panels in a grid layout (2x2)
    void PositionPanelsInGrid()
    {
        int rows = Mathf.CeilToInt(panels.Length / (float)columns);
        for (int i = 0; i < panels.Length; i++)
        {
            /*int row = i / columns;
            int col = i % columns;

            Vector3 panelPosition = new Vector3(col * spacing, -row * spacing, 0);
            panels[i].transform.localPosition = panelPosition;

            // Optional: Add button components to the panels for item selection*/
            Button button = panels[i].AddComponent<Button>();
            int index = i;
            button.onClick.AddListener(() => SpawnItem(index));
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

            // Disable the item GameObject as it will be instantiated later
            item.SetActive(false);
        }
    }

    // Spawn an item associated with the panel if spawn count is below 10
    void SpawnItem(int panelIndex)
    {
        if (panelIndex < items.Count && itemSpawnCount[panelIndex] < maxSpawnCount)
        {
            // Instantiate a new instance of the associated item
            GameObject itemPrefab = items[panelIndex];
            GameObject spawnedItem = Instantiate(itemPrefab, spawnArea);
            spawnedItem.SetActive(true);  // Activate the spawned item
            GameManageraccessories.Instance.accessoriesBagList.Add(spawnedItem);

            // Optionally set the position of the spawned item in the spawn area
            spawnedItem.transform.position = spawnArea.position;

            // Increase the spawn count for the selected panel
            itemSpawnCount[panelIndex]++;
        }
        else
        {
            Debug.Log("Max item spawn limit reached for this panel.");
        }
    }
}

