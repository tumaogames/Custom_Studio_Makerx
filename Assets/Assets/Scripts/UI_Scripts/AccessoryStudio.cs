using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryStudio : MonoBehaviour
{
    [SerializeField] private GameObject RingCanvas;
    [SerializeField] private GameObject NeckCanvas;
    [SerializeField] private Button slcRingButton;
    [SerializeField] private Button slcNeckButton;
    [SerializeField] private TMP_Text AccList;
    [SerializeField] private TMP_Text TotalPrice;
    [SerializeField] private TMP_Text LTypeDisp;
    [SerializeField] private TMP_Text LenghtDisp;
    [SerializeField] private TMP_Text TotalPriceText2;

    private void Start()
    {
        slcRingButton.onClick.AddListener(ShowRingCanvas);
        slcNeckButton.onClick.AddListener(ShowNeckCanvas);
    }

    public void OnEnable()
    {
        GameManageraccessories.Instance.AccList = AccList;
        GameManageraccessories.Instance.totalPrice = TotalPrice;
        GameManageraccessories.Instance.LTypeDisp = LTypeDisp;
        GameManageraccessories.Instance.LenghtDisp = LenghtDisp;
        GameManageraccessories.Instance.TotalPriceText = TotalPriceText2;
    }

    public void ShowRingCanvas()
    {
        RingCanvas.SetActive(true);
        NeckCanvas.SetActive(false);
        GameManageraccessories.Instance.isRing = true;
        GameManageraccessories.Instance.isNecLace = false;
    }

    public void ShowNeckCanvas()
    {
        RingCanvas.SetActive(false);
        NeckCanvas.SetActive(true);
        GameManageraccessories.Instance.isRing = false;
        GameManageraccessories.Instance.isNecLace = true;
    }
}

