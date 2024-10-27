using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryStudio : MonoBehaviour
{
    [SerializeField] private GameObject RingCanvas;
    [SerializeField] private GameObject NeckCanvas;
    [SerializeField] private Button slcRingButton;
    [SerializeField] private Button slcNeckButton;

    private void Start()
    {
        slcRingButton.onClick.AddListener(ShowRingCanvas);
        slcNeckButton.onClick.AddListener(ShowNeckCanvas);
    }

    public void ShowRingCanvas()
    {
        RingCanvas.SetActive(true);
        NeckCanvas.SetActive(false);
    }

    public void ShowNeckCanvas()
    {
        RingCanvas.SetActive(false);
        NeckCanvas.SetActive(true);
    }
}

