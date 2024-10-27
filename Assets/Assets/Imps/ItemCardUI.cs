using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardUI : MonoBehaviour
{
    [SerializeField] private Button transformButton;
    [SerializeField] private Button revertButton;
    [SerializeField] private GameObject objectToTransform;
    [SerializeField] private GameObject objectDefault;
    [SerializeField] private Renderer objectRenderer;

    private void Start()
    {
        transformButton.onClick.AddListener(TransformToObject);
        revertButton.onClick.AddListener(RevertToDefault);
    }

    private void TransformToObject()
    {
        if (objectDefault == null || objectToTransform == null)
        {
            Debug.LogError("Object default or object to transform is not assigned!");
            return;
        }

        objectDefault.SetActive(false);
        objectToTransform.SetActive(true);

        objectToTransform.transform.position = objectDefault.transform.position;
        objectToTransform.transform.rotation = objectDefault.transform.rotation;

        if (objectRenderer != null)
        {
            objectRenderer.material = objectDefault.GetComponent<Renderer>().material;
        }
    }

    private void RevertToDefault()
    {
        if (objectDefault == null || objectToTransform == null)
        {
            Debug.LogError("Object default or object to transform is not assigned!");
            return;
        }

        objectToTransform.SetActive(false);
        objectDefault.SetActive(true);

        objectDefault.transform.position = objectToTransform.transform.position;
        objectDefault.transform.rotation = objectToTransform.transform.rotation;

        if (objectRenderer != null)
        {
            objectRenderer.material = objectDefault.GetComponent<Renderer>().material;
        }
    }
}
