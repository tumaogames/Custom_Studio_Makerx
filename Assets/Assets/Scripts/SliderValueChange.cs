using UnityEngine;
using UnityEngine.UI; // For standard UI
using TMPro;      // Uncomment if you're using TextMeshPro

public class SliderValueChange : MonoBehaviour
{
    public Slider slider;        // The slider component
    //public  valueText;       // For standard UI text
    public TMP_Text valueText; // Uncomment for TextMeshPro

    void Start()
    {
        // Add a listener to call a method whenever the slider value changes
        slider.onValueChanged.AddListener(UpdateText);
        UpdateText(slider.value); // Initialize the text with the current slider value
    }

    // Method to update the text field based on the slider's value
    void UpdateText(float value)
    {
        valueText.text = value.ToString("0.0") + " inch"; // Format the value as needed (e.g., 1 decimal)
    }
}
