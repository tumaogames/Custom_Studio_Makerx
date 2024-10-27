using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMenu : MonoBehaviour
{
    public GameObject[] panels;  // Assign the 8 panels in the inspector
    public float radius = 200f;  // Radius of the circle in which panels will be placed

    void Start()
    {
        PositionPanels();
    }

    void PositionPanels()
    {
        float angleStep = 360f / panels.Length;  // Angle between each panel

        for (int i = 0; i < panels.Length; i++)
        {
            float angle = i * angleStep;  // Angle for this panel
            float radians = angle * Mathf.Deg2Rad;  // Convert degrees to radians

            float x = Mathf.Cos(radians) * radius;
            float y = Mathf.Sin(radians) * radius;

            // Set panel position relative to the RadialMenu center
            panels[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }
    }
}
