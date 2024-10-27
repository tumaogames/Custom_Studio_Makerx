using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    // Method to change color, triggered by button clicks
    public void ChangeColor(string colorName)
    {
        MeshRenderer meshRenderer = GameManager.Instance.currentDress.transform.GetChild(0).GetComponent<MeshRenderer>();

        if (meshRenderer != null && meshRenderer.materials.Length > 0)
        {
            // Access Element 0 of the material array
            Material material = meshRenderer.materials[0];

            // Check if the material uses the Universal Render Pipeline Lit shader
            if (material.shader.name == "Universal Render Pipeline/Lit")
            {
                Color newColor;
                ColorEnum gmColor = ColorEnum.Red;

                switch (colorName)
                {
                    case "Red":
                        newColor = Color.red;
                        gmColor = ColorEnum.Red;
                        break;
                    case "Blue":
                        newColor = Color.blue;
                        gmColor = ColorEnum.Blue;
                        break;
                    case "Green":
                        newColor = Color.green;
                        gmColor = ColorEnum.Green;
                        break;
                    case "Yellow":
                        newColor = Color.yellow;
                        gmColor = ColorEnum.Yellow;
                        break;
                    case "White":
                        newColor = Color.white;
                        gmColor = ColorEnum.White;
                        break;
                    case "Black":
                        newColor = Color.black;
                        gmColor = ColorEnum.Black;
                        break;
                    default:
                        Debug.LogWarning("Color not recognized!");
                        return;
                }

                // Set the _BaseColor property for the URP Lit shader
                material.SetColor("_BaseColor", newColor);
                GameManager.Instance.color = gmColor;
            }
            else
            {
                Debug.LogError("The material is not using the URP/Lit shader.");
            }
        }
        else
        {
            Debug.LogError("MeshRenderer or Material not found on target object!");
        }
    }
}
