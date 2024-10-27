using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingStudio : MonoBehaviour
{
    [SerializeField] private GameObject baseModel;
    [SerializeField] private DressManager dm;
    //[SerializeField] private GameObject baseModel2;
    //[SerializeField] private GameObject baseModel3;

    [SerializeField] private GameObject baseCloth; // Base cloth to be the target of transformations and material application
    [SerializeField] private Slider slHeight;
    [SerializeField] private Slider slDepth;

    [SerializeField] private GameObject[] clothingModels; // Array of clothing model prefabs
    [SerializeField] private Material[] materials; // Array of materials for clothing

    //[SerializeField] private Button[] itemButtons; // Buttons for selecting clothing models (ItemCardUI)
    //[SerializeField] private Button[] materialButtons; // Buttons for selecting materials (MaterialCardUI)

    private GameObject currentClotheModel; // Currently selected clothing model
    private Renderer baseClothRenderer; // Cache the Renderer of baseCloth

    private void Start()
    {
        // Initialize sliders
        //slHeight.minValue = .7f;
        //slHeight.maxValue = 1.25f;
        //slHeight.value = 1f;

        //slDepth.minValue = .7f;
        //slDepth.maxValue = 1.7f;
        //slDepth.value = 1f;

        // Cache the renderer of baseCloth
        baseClothRenderer = baseCloth.GetComponent<Renderer>();

        // Initially make baseCloth invisible
        if (baseClothRenderer != null)
        {
            baseClothRenderer.enabled = false; // Disable the renderer to make baseCloth invisible
        }

        // Initialize the ItemCardUI and MaterialCardUI
       // InitializeItemCardUI();
        //InitializeMaterialCardUI();
    }

    private void Update()
    {
        // Update the base model scale based on sliders
        //Vector3 scale = baseModel.transform.localScale;
        //Vector3 scale2 = baseModel2.transform.localScale;
        //Vector3 scale3 = baseModel3.transform.localScale;
        //scale.y = slHeight.value;
        //scale.x = slDepth.value;
        //scale.z = slDepth.value;
        //scale2.y = slHeight.value;
        //scale2.x = slDepth.value;
        //scale2.z = slDepth.value;
        //scale3.y = slHeight.value;
        //scale3.x = slDepth.value;
        //scale3.z = slDepth.value;
        //baseModel.transform.localScale = scale;
        //baseModel2.transform.localScale = scale2;
        //baseModel3.transform.localScale = scale3;
    }

    // Initialize the ItemCardUI with buttons linked to clothing models
    private void InitializeItemCardUI()
    {
        /*foreach (Button itemButton in itemButtons)
        {
            itemButton.onClick.AddListener(() =>
            {
                GameObject clotheModel = itemButton.GetComponent<ItemButtonData>().clotheModel;
                OnClotheModelSelected(clotheModel);
            });
        }*/
    }

    // Initialize the MaterialCardUI with buttons linked to materials
    private void InitializeMaterialCardUI()
    {
        /*foreach (Button materialButton in materialButtons)
        {
            materialButton.onClick.AddListener(() =>
            {
                Material material = materialButton.GetComponent<MaterialButtonData>().material;
                OnMaterialSelected(material);
            });
        }*/
    }

    // Called when a clothing model is selected from ItemCardUI
    public void OnClotheModelSelected(GameObject clotheModel)
    {
        // Remove the current clothing model if it exists
        if (currentClotheModel != null)
        {
            Destroy(currentClotheModel);
        }

        // Instantiate the new clothing model and attach it to the baseModel
        currentClotheModel = Instantiate(clotheModel, baseModel.transform);
        //currentClotheModel = Instantiate(clotheModel, baseModel2.transform);
        //currentClotheModel = Instantiate(clotheModel, baseModel3.transform);
        currentClotheModel.transform.localPosition = Vector3.zero;
        currentClotheModel.transform.localRotation = Quaternion.identity;

        // Make the baseCloth visible when an item is selected
        if (baseClothRenderer != null)
        {
            baseClothRenderer.enabled = true;
        }
        dm.dnameText.text = clotheModel.name;
    }

    // Called when a material is selected from MaterialCardUI
    public void OnMaterialSelected(Material material)
    {
        // Apply the material to the current clothing model (if any)
        if (currentClotheModel != null)
        {
            Renderer renderer = currentClotheModel.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }

        // Apply the material to the baseCloth
        if (baseClothRenderer != null)
        {
            baseClothRenderer.material = material;
        }
    }
}


// Script to hold data for item buttons (ItemCardUI)
public class ItemButtonData : MonoBehaviour
{
    public GameObject clotheModel; // The clothing model linked to this button
}

// Script to hold data for material buttons (MaterialCardUI)
public class MaterialButtonData : MonoBehaviour
{
    public Material material; // The material linked to this button
}