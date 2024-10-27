using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClothingStudioTest : MonoBehaviour
{
    [SerializeField] public GameObject baseModel;
    [SerializeField] private Slider slHeight;
    [SerializeField] private Slider slDepth;

    [SerializeField] private GameObject[] clothingModels; // Array of clothing model prefabs
    [SerializeField] private Material[] materials; // Array of materials for clothing

    [SerializeField] private Button[] itemButtons; // Buttons for selecting clothing models (ItemCardUI)
    [SerializeField] private Button[] materialButtons; // Buttons for selecting materials (MaterialCardUI)

    public GameObject currentClotheModel1; // Currently selected clothing model

    private void Start()
    {
        // Initialize sliders
        slHeight.minValue = .7f;
        slHeight.maxValue = 1.25f;
        slHeight.value = 1f;

        slDepth.minValue = .7f;
        slDepth.maxValue = 1.7f;
        slDepth.value = 1f;

        // Initialize the ItemCardUI and MaterialCardUI
        InitializeItemCardUI();
        InitializeMaterialCardUI();
    }

    private void Update()
    {
        // Update the base model scale based on sliders
        Vector3 scale = baseModel.transform.localScale;
        scale.y = slHeight.value;
        scale.x = slDepth.value;
        scale.z = slDepth.value;
        baseModel.transform.localScale = scale;
    }

    // Initialize the ItemCardUI with draggable items linked to clothing models
    private void InitializeItemCardUI()
    {
        foreach (Button itemButton in itemButtons)
        {
            var itemButtonData = itemButton.GetComponent<ItemButtonData1>();
            if (itemButtonData != null)
            {
                // Enable dragging of clothing items
                var dragHandler = itemButton.gameObject.AddComponent<ItemDragHandler>();
                dragHandler.clotheModel = itemButtonData.clotheModel;
                dragHandler.clothingStudio = this;
            }
        }
    }

    // Initialize the MaterialCardUI with draggable materials
    private void InitializeMaterialCardUI()
    {
        foreach (Button materialButton in materialButtons)
        {
            var materialButtonData = materialButton.GetComponent<MaterialButtonData1>();
            if (materialButtonData != null)
            {
                // Enable dragging of materials
                var dragHandler = materialButton.gameObject.AddComponent<MaterialDragHandler>();
                dragHandler.material = materialButtonData.material;
                dragHandler.clothingStudio = this;
            }
        }
    }

    // Called when a clothing model is dropped on the base model
    public void OnClotheModelDropped(GameObject clotheModel)
    {
        // Remove the current clothing model if it exists
        if (currentClotheModel1 != null)
        {
            Destroy(currentClotheModel1);
        }

        // Instantiate the new clothing model and attach it to the baseModel
        currentClotheModel1 = Instantiate(clotheModel, baseModel.transform);
        currentClotheModel1.transform.localPosition = Vector3.zero;
        currentClotheModel1.transform.localRotation = Quaternion.identity;
    }

    // Called when a material is dropped on the clothing model
    public void OnMaterialDropped(Material material)
    {
        // Apply the material to the current clothing model (if any)
        if (currentClotheModel1 != null)
        {
            Renderer renderer = currentClotheModel1.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }
    }
}

// Script to hold data for item buttons (ItemCardUI)
public class ItemButtonData1 : MonoBehaviour
{
    public GameObject clotheModel; // The clothing model linked to this button
}

// Script to hold data for material buttons (MaterialCardUI)
public class MaterialButtonData1 : MonoBehaviour
{
    public Material material; // The material linked to this button
}

// Drag handler for clothing items
public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject clotheModel;
    public ClothingStudioTest clothingStudio;
    private GameObject dragObject;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragObject = Instantiate(clotheModel);
        dragObject.transform.SetParent(clothingStudio.transform);
        dragObject.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject != null)
        {
            dragObject.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null && eventData.pointerEnter == clothingStudio.baseModel)
        {
            clothingStudio.OnClotheModelDropped(clotheModel);
        }

        Destroy(dragObject);
    }
}

// Drag handler for materials
public class MaterialDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Material material;
    public ClothingStudioTest clothingStudio;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Optionally, create a visual representation of the material while dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Handle dragging of the material
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (clothingStudio.currentClotheModel1 != null && eventData.pointerEnter != null)
        {
            Renderer renderer = clothingStudio.currentClotheModel1.GetComponent<Renderer>();
            if (renderer != null)
            {
                clothingStudio.OnMaterialDropped(material);
            }
        }
    }
}
