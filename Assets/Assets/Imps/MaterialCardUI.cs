using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialCardUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private Button applyButton;
    [SerializeField] private Renderer targetRenderer;
    private MaterialUI selectedMaterialUI;

    private void Start()
    {
        applyButton.onClick.AddListener(ApplySelectedItem);
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Check if the dropped object has a MaterialUI component
        var droppedMaterialUI = eventData.pointerDrag.GetComponent<MaterialUI>();
        if (droppedMaterialUI != null)
        {
            selectedMaterialUI = droppedMaterialUI;
            // Optionally update the UI to reflect the selected item
            Debug.Log("Item selected: " + selectedMaterialUI.name);
        }
    }

    private void ApplySelectedItem()
    {
        if (selectedMaterialUI != null)
        {
            if (selectedMaterialUI.Material != null)
            {
                targetRenderer.material = selectedMaterialUI.Material;
            }
            else if (selectedMaterialUI.Texture != null)
            {
                targetRenderer.material.mainTexture = selectedMaterialUI.Texture;
            }
            else if (selectedMaterialUI.GameObject != null)
            {
                // Apply other properties or instantiate the game object if needed
                Instantiate(selectedMaterialUI.GameObject, targetRenderer.transform.position, targetRenderer.transform.rotation);
            }
        }
    }
}
