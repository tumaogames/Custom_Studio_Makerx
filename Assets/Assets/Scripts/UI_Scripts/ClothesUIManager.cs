using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClothesUIManager : MonoBehaviour
{
    public TextMeshProUGUI colorTxt;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI dressNameTxt;
    public TextMeshProUGUI heightTxt;
    public TextMeshProUGUI bustTxt;
    public TextMeshProUGUI hipTxt;
    public TextMeshProUGUI waistTxt;

    public TMP_Text dressSliderVal;
    public Slider heightSliderVal;
    public Slider bustSliderVal;
    public Slider hipSliderVal;
    public Slider waistSliderVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        // Subscribe to the GameManager variable change event
        GameManager.Instance.priceOnVariableChanged += priceUpdateOnVariableChanged;
        GameManager.Instance.dressNameOnVariableChanged += dressNameUpdateOnVariableChanged;
        GameManager.Instance.heightOnVariableChanged += heightUpdateOnVariableChanged;
        GameManager.Instance.bustOnVariableChanged += bustUpdateOnVariableChanged;
        GameManager.Instance.hipOnVariableChanged += hipUpdateOnVariableChanged;
        GameManager.Instance.colorOnVariableChanged += colorUpdateOnVariableChanged;
        GameManager.Instance.waistOnVariableChanged += waistUpdateOnVariableChanged;
    }

    private void OnDisable()
    {
        // Subscribe to the GameManager variable change event
        GameManager.Instance.priceOnVariableChanged -= priceUpdateOnVariableChanged;
        GameManager.Instance.dressNameOnVariableChanged -= dressNameUpdateOnVariableChanged;
        GameManager.Instance.heightOnVariableChanged -= heightUpdateOnVariableChanged;
        GameManager.Instance.bustOnVariableChanged -= bustUpdateOnVariableChanged;
        GameManager.Instance.hipOnVariableChanged -= hipUpdateOnVariableChanged;
        GameManager.Instance.colorOnVariableChanged -= colorUpdateOnVariableChanged;
        GameManager.Instance.waistOnVariableChanged -= waistUpdateOnVariableChanged;
    }

    private void priceUpdateOnVariableChanged(float newValue)
    {
        priceTxt.text = newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }
    private void dressNameUpdateOnVariableChanged(string newValue)
    {
        dressNameTxt.text = newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }
    private void heightUpdateOnVariableChanged(float newValue)
    {
        heightTxt.text = newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }
    private void bustUpdateOnVariableChanged(float newValue)
    {
        bustTxt.text = newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }
    private void hipUpdateOnVariableChanged(float newValue)
    {
        hipTxt.text = newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }
    private void colorUpdateOnVariableChanged(ColorEnum newValue)
    {
        colorTxt.text = "Color: " + newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }
    private void waistUpdateOnVariableChanged(float newValue)
    {
        waistTxt.text = newValue.ToString();
        // This method will be called whenever the variable 'a' changes
        Debug.Log("Observer notified: Variable 'a' is now " + newValue);
    }



    public void UpdateText()
    {
        dressNameTxt.text = "Dress Name:";
        dressNameTxt.text = dressNameTxt.text + " " + GameManager.Instance.dressName.ToString();
        colorTxt.text = "Color:";
        colorTxt.text = colorTxt.text + " " + GameManager.Instance.color.ToString();
        priceTxt.text = "Price:";
        priceTxt.text = priceTxt.text + " Php " + GameManager.Instance.price.ToString();
        bustTxt.text = "Bust:";
        bustTxt.text = bustTxt.text + " " + GameManager.Instance.bust.ToString();
        hipTxt.text = "Hip:";
        hipTxt.text = hipTxt.text + " " + GameManager.Instance.hip.ToString();
        heightTxt.text = "Height:";
        heightTxt.text = heightTxt.text + " " + GameManager.Instance.height.ToString();
        waistTxt.text = "Waist:";
        waistTxt.text = waistTxt.text + " " + GameManager.Instance.waist.ToString();

        //dressSliderVal.text = GameManager.Instance.dressName;
        //heightSliderVal.value = GameManager.Instance.height;
        //bustSliderVal.value = GameManager.Instance.bust;
        //hipSliderVal.value = GameManager.Instance.hip;
        //waistSliderVal.value = GameManager.Instance.waist;
    }
}
