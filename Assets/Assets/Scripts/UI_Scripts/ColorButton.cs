using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public GameObject targetObject;
    public Button colorChangeButton;
    public Color targetColor = Color.white;

    private void Start()
    {
        if (colorChangeButton != null)
        {
            colorChangeButton.onClick.AddListener(ChangeColor);
        }
    }

    public void ChangeColor()
    {
        if (targetObject != null)
        {
            MeshRenderer meshRenderer = targetObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null && meshRenderer.materials.Length > 0)
            {
                Material material = meshRenderer.materials[0];

                // Set the _BaseColor property for URP Lit shader
                material.SetColor("_BaseColor", targetColor);
            }
            else
            {
                Debug.LogWarning("No materials assigned or no MeshRenderer found.");
            }
        }
        else
        {
            Debug.LogWarning("No target object assigned.");
        }
    }
}
