using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neck_Grid_Menu : MonoBehaviour
{
    [SerializeField] private GameObject panelPrefab; // Prefab for the panel buttons
    [SerializeField] private GameObject itemPrefab;  // Prefab for the items to spawn
    [SerializeField] private Transform itemSpawnParent; // Parent object where items will be spawned
    [SerializeField] private Transform base_Neck; // Anchor point for the DropAreas
    [SerializeField] private Transform spawnField; // The location where the items will spawn
    public GridLayoutGroup gridLayoutGroup; // The Grid Layout component

    private int[] itemCounts = new int[4]; // Keeps track of items spawned per panel
    private const int maxItems = 10; // Maximum items to spawn per panel

    void Start()
    {
        CreateGridMenu();
    }

    void CreateGridMenu()
    {
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = 2; // 2x2 layout

        for (int i = 0; i < 4; i++)
        {
            GameObject panel = Instantiate(panelPrefab, gridLayoutGroup.transform);
            int panelIndex = i; // Capture index for lambda

            // Get button in the panel and set up its listener
            Button button = panel.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => SpawnItem(panelIndex));
        }
    }

    void SpawnItem(int panelIndex)
    {
        if (itemCounts[panelIndex] < maxItems)
        {
            // Spawn the item at the defined spawnField location
            GameObject newItem = Instantiate(itemPrefab, spawnField.position, Quaternion.identity, itemSpawnParent);

            // Optionally, attach the newItem to the base_Neck anchor point for drop areas
            newItem.transform.SetParent(base_Neck);

            itemCounts[panelIndex]++;
            Debug.Log($"Spawned item from panel {panelIndex}. Total items: {itemCounts[panelIndex]}");
        }
        else
        {
            Debug.Log($"Panel {panelIndex} has reached the maximum number of items.");
        }
    }
}
